namespace ConsoleApp.Classes.Models
{
    public class UserId
    {
        public string Value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.Value = value;
        }
    }

    public class UserName
    {
        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。", nameof(value));

            this.Value = value;
        }

        public string Value { get; }
    }

    public class User
    {
        public UserId Id; // 識別子
        public UserName Name;
        public string MailAddress;

        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(Id));            

            this.Id = id;
            ChangeUserName(name);
        }

        public void ChangeUserName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Value.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。", nameof(name));

            this.Name = name;
        }

        // ユーザー名は可変なので、識別子だけを比較して等価であるかを判断するため、
        // 属性の違いに囚われず、同一性の比較が可能になる
        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false; 
            if (ReferenceEquals (this, other)) return true;
            return Equals(Id, other.Id); // 比較は識別子である id 同士で行われる
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
            return (Id != null ? Id.GetHashCode() : 0);
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
