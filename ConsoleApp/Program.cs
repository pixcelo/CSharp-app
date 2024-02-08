using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Implementations;
using ConsoleApp.Classes.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main(string[] args)
    {        
        // 依存性注入コンテナの設定
        var services = new ServiceCollection();
        ConfigureServices(services);

        // サービスプロバイダのビルド
        using (var serviceProvider = services.BuildServiceProvider())
        {
            // サービスの取得と使用
            var userRepository = serviceProvider.GetService<IUserRepository>();

            var user = new User(
                new UserId("T001"),
                new UserName("Tom")
            );

            // リポジトリを利用したユーザー作成処理
            userRepository.Save(user);

            // インメモリのリポジトリでテスト
            var head = userRepository.Find(user.Name);
            Console.WriteLine(head.Name);
        }

    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // サービスの登録
        // services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserRepository, InMemoryUserRepository>();
    }
}