using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Implementations;
using ConsoleApp.Classes.Repositories.Interfaces;
using ConsoleApp.Classes.Services.DomainService;
using ConsoleApp.Classes.Services.ApplicationService;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using ConsoleApp.Classes.Command;

class Program
{
    private static ServiceProvider serviceProvider;

    public static void Main(string[] args)
    {
        StartUp();

        while (true)
        {
            Console.WriteLine("Input user name");
            Console.Write(">");
            var input = Console.ReadLine();
            var userApplicationService = serviceProvider.GetRequiredService<UserApplicationService>();
            var command = new UserRegisterCommand(input);
            userApplicationService.Register(command);

            Console.WriteLine("----------------");
            Console.WriteLine("user created:");
            Console.WriteLine("----------------");
            Console.WriteLine("user name:");
            Console.WriteLine("- " + input);
            Console.WriteLine("----------------");

            Console.WriteLine("continue? (y/n)");
            Console.WriteLine(">");
            var yesOrNo = Console.ReadLine();
            if (yesOrNo == "n")
            {
                break;
            }
        }
    }

    private static void StartUp()
    {
        // 依存性注入コンテナの設定
        var serviceCollection = new ServiceCollection();

        // サービスの登録
        // serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddSingleton<IUserRepository, InMemoryUserRepository>();
        serviceCollection.AddTransient<UserService>();
        serviceCollection.AddTransient<UserApplicationService>();

        // サービスプロバイダのビルド
        serviceProvider = serviceCollection.BuildServiceProvider();
    }
}