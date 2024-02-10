using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;

namespace ConsoleApp.Classes.Repositories.Implementations
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public EFUserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public User Find(UserName name)
        {
            var target = context.Users
                .FirstOrDefault(userData => userData.Name == name.Value);

            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public void Save(User user)
        {
            var found = context.Users.Find(user.Id.Value);

            if (found == null)
            {
                var data = ToDataModel(user);
                context.Users.Add(data);
            }
            else
            {
                var data = Transfer(user, found);
                context.Users.Update(data);
            }

            context.SaveChanges();
        }

        public void Delete(User user)
        {
            var found = context.Users.Find(user.Id.Value);

            if (found == null)
            {
                throw new Exception("ユーザーが見つかりませんでした。");
            }
            
            context.Users.Remove(found);
            context.SaveChanges();
        }

        private User ToModel(UserDataModel from)
        {
            return new User(
                new UserId(from.Id),
                new UserName(from.Name)
            );
        }

        private UserDataModel Transfer(User from, UserDataModel model)
        {
            model.Id = from.Id.Value;
            model.Name = from.Name.Value;
            return model;
        }

        private UserDataModel ToDataModel(User from)
        {
            return new UserDataModel
            {
                Id = from.Id.Value,
                Name = from.Name.Value,
            };
        }
    }
}
