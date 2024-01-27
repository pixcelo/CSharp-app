# .NET8 MVC App
MVCアプリケーション初期設定

## Nuget
SQLServerを使う場合<br>
パッケージををインストール
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

コマンドが通らない場合、`dotnet tool`グローバル化
```
dotnet tool install --global dotnet-ef
```

## ビルド
コマンドからビルド
```
dotnet build
```

## モデルを追加
```cs
namespace WebAppMVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
```

## DbContextを追加
```cs
using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> BlogPosts { get; set; }
    }
}
```

## Programs.csにDbcontextを追加
.NET6以降は`startup.cs`は廃止
```cs
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("BlogContext");
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## マイグレーション
### DB設定
```
dotnet ef migrations add InitialCreate
```
実行すると`Migrations`フォルダが作成される

`appsettings.json`にDB接続情報を記述(今回はPCのローカルDBにwindows認証で設定)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "BlogContext": "Server=(localdb)\\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;"
  }
}
```

```
dotnet ef database update
```
実行すると設定したSQLServerインスタンスにマイグレーションファイルのデータベース、テーブル等が作成される

### シーディング
`DbContext`クラスにシーディングを追加
```cs
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

namespace WebAppMVC.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Name = "First Blog" },
                new Blog { Id = 2, Name = "Second Blog" },
                new Blog { Id = 3, Name = "Third Blog" }
                // その他のシードデータを追加...
            );
        }
    }
}
```

マイグレーション追加
```
dotnet ef migrations add SeedBlog
dotnet ef database update
```
実行すると`Blog`テーブルにインサートされる


## APIキーを叩く

シークレット ストレージを有効にする
```
dotnet user-secrets init
```

シークレットマネージャーにAPIキーを保存
```
dotnet user-secrets set "OpenWeatherApiKey" "YOUR_API_KEY"
```
※参考<br>
[ASP.NET Core での開発におけるアプリ シークレットの安全な保存](https://learn.microsoft.com/ja-jp/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)

アプリケーションでの読み込み
```cs
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebAppMVC.Models;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenWeatherApiKey"];
    }

    public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
    {
        var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<WeatherModel>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
```

`Program.cs`にてDIコンテナへのサービス登録
```cs
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<WeatherService>(); // 追加
```

`WeatherController.cs`を作成 (ビュー、モデルも併せて作成)
```cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.Services;

namespace WebAppMVC.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _weatherService.GetCurrentWeatherAsync("Tokyo");
            return View(weather);
        }
    }
}
```

## ログイン機能の実装
### ユーザーモデルを作成
```cs
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    // その他のプロパティ...
}
```

DbContextの設定
```cs
public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; } // 追加

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // シーディング追加
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "testuser", Password = "123" }
        );
    }
}
```

マイグレーションの作成 `dotnet ef migrations add Create{テーブル名}Table`
```
dotnet ef migrations add CreateUserTable
dotnet ef migrations add SeedTestUser
```

マイグレーションを作成した後に、データベースに適用
```
dotnet ef database update
```

LoginViewModelを作成 `ViewsModels/LoginViewModel.cs`
```cs
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
```

コントローラー作成
```cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;

public class AccountController : Controller
{
    private readonly BlogContext _context;

    public AccountController(BlogContext context)
    {
        _context = context;
    }

    // GET: Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // ユーザー認証ロジック（仮）
        var user = await _context.User
            .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password); // 本来はハッシュを比較

        if (user != null)
        {
            // 認証成功
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
                // その他のクレーム
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        // 認証失敗
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    // POST: Account/Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
```

`Program.cs`に認証サービスの設定
```cs
var builder = WebApplication.CreateBuilder(args);

// その他のサービスの設定...

// 認証サービスを追加
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        });

// その他のサービスの設定...

var app = builder.Build();

// その他のミドルウェア設定...

app.UseAuthentication();
app.UseAuthorization();

// その他のミドルウェア設定...

app.Run();
```

View作成
```html
@using WebAppMVC.ViewModels
@model LoginViewModel

<h2>Login</h2>

<form asp-action="Login" method="post">
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    <div class="form-group">
        <label asp-for="Username"></label>
        <input asp-for="Username" class="form-control" />
        <span asp-validation-for="Username" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Password"></label>
        <input asp-for="Password" class="form-control" />
        <span asp-validation-for="Password" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Login</button>
</form>
```