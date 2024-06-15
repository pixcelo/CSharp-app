using DDD.Domain.Entities;
using DDD.Domain.Repositoriers;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"
                    SELECT AreaId, AreaName
                    FROM Areas
                    ";

            //return SQLiteHelper.Query<AreaEntity>(sql, CreateEntity);

            // Queryの後のジェネリック型は省略できる
            // 第二引数のデリゲートはCreateEntityメソッドを呼び出すだけなので、ラムダ式で置き換える
            return SQLiteHelper.Query(
                sql,
                reader =>
                {
                    return new AreaEntity(
                        Convert.ToInt32(reader["AreaId"]),
                        Convert.ToString(reader["AreaName"]));
                });
        }

        //private AreaEntity CreateEntity(SQLiteDataReader reader)
        //{
        //    return new AreaEntity(
        //        Convert.ToInt32(reader["AreaId"]),
        //        Convert.ToString(reader["AreaName"]));
        //}

        //public IReadOnlyList<AreaEntity> GetData()
        //{
        //    string sql = @"
        //        SELECT AreaId, AreaName
        //        FROM Areas                
        //        ";

        //    var result = new List<AreaEntity>();

        //    using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
        //    using (var command = new SQLiteCommand(sql, connection))
        //    {
        //        connection.Open();

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                result.Add(
        //                    new AreaEntity(
        //                        Convert.ToInt32(reader["AreaId"]),
        //                        Convert.ToString(reader["AreaName"]))
        //                    );
        //            }
        //        }
        //    }

        //    return result.AsReadOnly();
        //}
    }
}
