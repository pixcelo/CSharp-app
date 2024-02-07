using ConsoleApp.Classes.Models;

namespace ConsoleApp.Classes.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Save(AppUser user);
        AppUser Find(AppUser.UserName name);
    }
}
