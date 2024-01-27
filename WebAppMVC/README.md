# MVC
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