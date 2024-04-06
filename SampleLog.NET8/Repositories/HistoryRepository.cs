using Microsoft.Data.SqlClient;
using SampleLog.NET8.Models;
using System.Configuration;

namespace SampleLog.NET8.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Save(History hisotory)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
                    INSERT INTO 
                    history (operation, result)
                    VALUES  (@operation, @result)
                ";
                
                command.Parameters.Add(new SqlParameter("@operation", hisotory.Operation));
                command.Parameters.Add(new SqlParameter("@result", hisotory.Result));
                command.ExecuteNonQuery();
            }
        }

        public void Delete(History hisotory)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "DELETE FROM history WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", hisotory.ID));
                command.ExecuteNonQuery();
            }
        }

        public History Find(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM history WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", id));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var Id = reader["id"] as int?;
                        var operation = reader["operation"] as string;
                        var result = reader["result"] as string;
                        return new History()
                        {
                            ID = (int)Id,
                            Operation = operation,
                            Result = result
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
