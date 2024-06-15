using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    internal class SQLiteHelper
    {
        internal const string ConnectionString = @"Data Source=C:\Users\bodom\Documents\csharp\DDD\DDD.db;Version=3;";

        internal static IReadOnlyList<T> Query<T>(string sql, Func<SQLiteDataReader, T> CreateEntity)
        {
            var result = new List<T>();

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(CreateEntity(reader));
                    }
                }
            }

            return result;
        }
    }
}
