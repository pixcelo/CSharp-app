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



    }
}
