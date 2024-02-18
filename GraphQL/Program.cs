var builder = WebApplication.CreateBuilder(args);

// GraphQL
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Map GraphQL
app.MapGraphQL();

app.Run();
