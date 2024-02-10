using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;

namespace ConsoleApp.Classes.Repositories.Implementations
{
    public class InMemoryUserRepository : IUserRepository
    {
        // インメモリのデータストアは、単体テストや統合テストを行う際に、外部のデータベースへの依存を排除する
        // テストの実行速度が向上し、テスト環境のセットアップが容易になる
        public Dictionary<UserId, User> Store { get; } = new Dictionary<UserId, User>();

        public User Find(UserName userName)
        {
            var target = Store.Values
                .FirstOrDefault(user => userName.Equals(user.Name));

            if (target != null)
            {
                // インスタンスを直接返さずディープコピーを行う
                // 復元したインスタンスへの操作がリポジトリ内で保持しているインスタンスに影響を及ぼすことを防ぐため
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        public void Save(User user)
        {
            // 保存時もディープコピーを行う
            Store[user.Id] = Clone(user);
        }

        public void Delete(User user)
        {
            Store[user.Id] = null;
        }

        // ディープコピーを行うメソッド
        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }
    }
}
