using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Implementations;
using ConsoleApp.Classes.Repositories.Interfaces;
using ConsoleApp.Classes.Services.DomainService;
using ConsoleApp.Classes.Services.ApplicationService;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    private static ServiceProvider serviceProvider;

    public static void Main(string[] args)
    {
        StartUp();
    }

    private static void StartUp()
    {
        // 依存性注入コンテナの設定
        var serviceCollection = new ServiceCollection();

        // サービスの登録
        // serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<IUserRepository, InMemoryUserRepository>();
        serviceCollection.AddTransient<UserService>();
        serviceCollection.AddTransient<UserApplicationService>();

        // サービスプロバイダのビルド
        using (serviceProvider = serviceCollection.BuildServiceProvider())
        {
            // サービスの取得と使用
            var userRepository = serviceProvider.GetRequiredService<IUserRepository>();

            var user = new User(
                new UserId("T001"),
                new UserName("Tom")
            );

            // リポジトリを利用したユーザー作成処理
            userRepository.Save(user);

            // インメモリのリポジトリでテスト
            var head = userRepository.Find(user.Name);
            Console.WriteLine(head.Name.Value);
        }
    }
}