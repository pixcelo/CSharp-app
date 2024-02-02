namespace ConsoleApp.Classes.Models
{
    class UserId
    {
        private string value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }
    }

    class User
    {
        private readonly UserId id; // 識別子
        private string name;

        public User(UserId id, string name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));            

            this.id = id;
            ChangeUserName(name);
        }

        public void ChangeUserName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。", nameof(name));

            this.name = name;
        }

        // ユーザー名は可変なので、識別子だけを比較して等価であるかを判断するため、
        // 属性の違いに囚われず、同一性の比較が可能になる
        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false; 
            if (ReferenceEquals (this, other)) return true;
            return Equals(id, other.id); // 比較は識別子である id 同士で行われる
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User) obj);            
        }

        public override int GetHashCode()
        {
            return (id != null ? id.GetHashCode() : 0);
        }

        // エンティティの比較
        void Check(User leftUser, User rightUser)
        {
            if (leftUser.Equals(rightUser))
            {
                Console.WriteLine("同一のユーザーです");
            }
            else
            {
                Console.WriteLine("別のユーザーです");
            }
        }
    }
}
