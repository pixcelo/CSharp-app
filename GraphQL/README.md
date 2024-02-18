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

## GraphQL クエリ

Operations
```
{
    hello
}
```

Response
```json
{
  "data": {
    "hello": "Hello, World!"
  }
}
```

Operations
```
{
    hello(name "Tom")
}
```

Response
```json
{
  "data": {
    "hello": "Hello, Tom!"
  }
}
```

Operations
```
{
    hello(name: "Tom")
    books {
        title
    }
}
```

Response
```json
{
  "data": {
    "hello": "Hello, Tom!",
    "books": [
      {
        "title": "C# in Depth"
      },
      {
        "title": "C# in Depth 2nd Edition"
      }
    ]
  }
}
```

Operations
```
{
    hello(name: "Tom")
    books {
        title
        author {            
          name
        }
    }
}
```

Response
```json
{
  "data": {
    "hello": "Hello, Tom!",
    "books": [
      {
        "title": "C# in Depth",
        "author": {
          "name": "Jon Skeet"
        }
      },
      {
        "title": "C# in Depth 2nd Edition",
        "author": {
          "name": "Jon Skeet"
        }
      }
    ]
  }
}
```


## Reference
- [.NET での GraphQL 入門 - Michael Staib - NDC コペンハーゲン 2022](https://www.youtube.com/watch?v=qrh97hToWpM)