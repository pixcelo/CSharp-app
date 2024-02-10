using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;

namespace ConsoleApp.Classes.Services.ApplicationService
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserApplicationService(IUserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        /// <summary>
        /// ユーザー登録
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="Exception"></exception>
        public void Register(string name)
        {
            var user = new User(
                new UserId(Guid.NewGuid().ToString()),
                new UserName(name)
            );

            // ユーザーの重複確認をドメインサービスに依頼
            if (userService.Exists(user))
            {
                throw new Exception("ユーザーは既に存在します。");
            }
            
            // リポジトリにインスタンスの永続化を依頼
            userRepository.Save(user);
        }

        /// <summary>
        /// ユーザー情報取得
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User Get(string userName)
        {
            var targetUserName = new UserName(userName);
            var user = userRepository.Find(targetUserName);

            return user;
        }
    }
}
