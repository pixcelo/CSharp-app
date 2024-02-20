using ConferencePlanner.GraphQL;
using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// サービスの登録
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite("Data Source=conferences.db"));

builder.Services
	.AddGraphQLServer()
    .AddQueryType<Query>()
	.AddMutationType<Mutation>();

var app = builder.Build();

// ルーティングのミドルウェアを追加
app.UseRouting();

// エンドポイントのミドルウェアを設定
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();
