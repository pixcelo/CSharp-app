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
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false; 
            if (ReferenceEquals (this, other)) return true;
            return Equals(id, other.id);
        }
    }
}
