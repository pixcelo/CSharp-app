using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    internal class SQLiteHelper
    {
        internal const string ConnectionString = @"Data Source=C:\Users\bodom\Documents\csharp\DDD\DDD.db;Version=3;";

        /// <summary>
        /// 全件取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="CreateEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> CreateEntity)
        {
            return Query(sql, null, CreateEntity);
        }

        /// <summary>
        /// 全件取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="CreateEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters, 
            Func<SQLiteDataReader, T> CreateEntity)
        {
            var result = new List<T>();

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }                

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

        /// <summary>
        /// 1件のみ取得する nullEntiryはnullを返却するためのもの
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="CreateEntity"></param>
        /// <param name="nullEntity"></param>
        /// <returns></returns>
        internal static T QuerySingle<T>(
            string sql,            
            Func<SQLiteDataReader, T> CreateEntity,
            T nullEntity)
        {
            return QuerySingle(sql, null, CreateEntity, nullEntity);
        }

        /// <summary>
        /// 1件のみ取得する nullEntiryはnullを返却するためのもの
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="CreateEntity"></param>        
        /// <param name="nullEntity"></param>
        /// <returns></returns>
        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> CreateEntity,            
            T nullEntity)
        {
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return CreateEntity(reader);
                    }
                }
            }

            return nullEntity;
        }
    }
}
