using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;
using ConsoleApp.Classes.Services;

class Program
{
    private IUserRepository userRepository;

    public Program(IUserRepository userRepository) 
    {
        this.userRepository = userRepository;
    }

    public static void Main(string[] args)
    {
        //var MyMoney = new Money(1000, "JPY");
        //var allowance = new Money(3000, "JPY");
        //var result = MyMoney.Add(allowance);

        // リポジトリを利用したユーザー作成処理
        
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

        userRepository.Save(user);
    }
}