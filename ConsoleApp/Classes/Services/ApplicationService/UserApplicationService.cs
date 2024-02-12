using ConsoleApp.Classes.Command;
using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;
using ConsoleApp.Classes.Services.DomainService;

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
        public void Register(UserRegisterCommand command)
        {
            var user = new User(
                new UserId(Guid.NewGuid().ToString()),
                new UserName(command.Name)
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
        public UserData Get(string userName)
        {
            var targetUserName = new UserName(userName);
            var user = userRepository.Find(targetUserName);

            //return user;

            if (user == null)
            {
                return null;
            }

            // 直接ユーザーを返さず、DTOを返すことでドメインオブジェクトを隠ぺいする
            return new UserData(user);
        }

        /// <summary>
        /// ユーザー更新
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="mailAddress"></param>
        /// <exception cref="Exception"></exception>
        public void Update(string userName, string mailAddress)
        {
            var targetUserName = new UserName(userName);
            var user = userRepository.Find(targetUserName);

            if (user == null)
            {
                throw new Exception("ユーザーが見つかりませんでした。");
            }

            user.MailAddress = mailAddress;
            userRepository.Save(user);
        }

        public void Delete(string userName)
        {
            var targetUserName = new UserName(userName);
            var user = userRepository.Find(targetUserName);

            if (user == null)
            {
                throw new Exception("ユーザーが見つかりませんでした。");
            }

            userRepository.Delete(user);
        }
    }
}
