# ASP.NET Core GraphQL

ASP.NET Core で新しい空のプロジェクトを作成
```bash
dotnet new web
```

GraphQL パッケージを追加
```bash
dotnet add package HotChocolate.AspNetCore
```

実行
```bash
# dotnet watch
dotnet watch --no-hot-reload
```

URLにアクセス
http://localhost:5165/graphql/

GraphQL クエリ
```
{
    hello
}
```

```
{
    hello(name "Tom")
}
```


## Reference
- [.NET での GraphQL 入門 - Michael Staib - NDC コペンハーゲン 2022](https://www.youtube.com/watch?v=qrh97hToWpM)