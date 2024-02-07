using ConsoleApp.Classes.Models;
using ConsoleApp.Classes.Repositories.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp.Classes.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public AppUser Find(AppUser.UserName name)
        {            
            throw new NotImplementedException();
        }

        public void Save(AppUser user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
                    MERGE INTO users
                        USING (
                        SELECT @id AS id, @nmame AS name
                    ) AS data
                    ON users.id = data.id
                    WHEN MATCHED THEN
                        UPDATE SET name = data.name
                    WHEN NOT MATCHED THEN
                        INSERT (id, name)
                        VALUES (data.id, data.name);
                ";

                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.ExecuteNonQuery();
            }
        }
    }
}
