using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;

namespace ConsoleApp.Classes.Services
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Exists(AppUser user)
        {
            var found = userRepository.Find(user.Name);

            return found != null;
        }
    }
}
