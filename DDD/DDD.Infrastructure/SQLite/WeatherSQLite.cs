using DDD.Domain.Entities;
using DDD.Domain.Repositoriers;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DDD.Infrastracture.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"
                SELECT DataDate, Condition, Temperature
                FROM Weather
                WHERE AreaId = @AreaId
                ORDER BY DataDate DESC
                LIMIT 1
                ";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId", areaId),
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                        areaId,
                        Convert.ToDateTime(reader["DataDate"]),
                        Convert.ToInt32(reader["Condition"]),
                        Convert.ToSingle(reader["Temperature"]));
                },
                null);
        }

        //public WeatherEntity GetLatest(int areaId)
        //{
        //    string sql = @"
        //        SELECT DataDate, Condition, Temperature
        //        FROM Weather
        //        WHERE AreaId = @AreaId
        //        ORDER BY DataDate DESC
        //        LIMIT 1
        //        ";
            
        //    using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
        //    using (var command = new SQLiteCommand(sql, connection))
        //    {
        //        connection.Open();

        //        command.Parameters.AddWithValue("@AreaId", areaId);
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                return new WeatherEntity(
        //                    areaId,
        //                    Convert.ToDateTime(reader["DataDate"]),
        //                    Convert.ToInt32(reader["Condition"]),
        //                    Convert.ToSingle(reader["Temperature"]));
        //            }
        //        }
        //    }

        //    return null;
        //}
    }
}
