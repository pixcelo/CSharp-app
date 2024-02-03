using System.Xml.Linq;

namespace ConsoleApp.Classes.Models
{
    public class AppUser
    {
        public AppUser(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
        }

        public UserId Id { get; }
        public UserName Name { get; }

        public class UserId
        {
            public UserId(string value)
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                
                value = value;
            }

            public string Value { get; }
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
    }
}
