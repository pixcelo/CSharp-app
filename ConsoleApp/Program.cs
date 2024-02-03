using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Services;
using System.Configuration;

class Program
{   
    public static void Main(string[] args)
    {
        var MyMoney = new Money(1000, "JPY");
        var allowance = new Money(3000, "JPY");
        var result = MyMoney.Add(allowance);

        // ユーザー作成のユースケース

    }

    public void CreateUser(string userName)
    {
        var user = new AppUser(
            new AppUser.UserName(userName)
        );

        var userService = new UserService();
        if (userService.Exists(user))
        {
            throw new Exception($"{userName}は既に存在しています");
        }

        //var connectionString = ConfigurationManager.ConnectionStrings["FooConection"].ConnectionString;
        // ...
    }
}