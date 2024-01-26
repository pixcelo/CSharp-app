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