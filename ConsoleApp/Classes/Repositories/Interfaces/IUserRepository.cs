using ConsoleApp.Classes.Models;

namespace ConsoleApp.Classes.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        User Find(UserName name);        
    }
}
