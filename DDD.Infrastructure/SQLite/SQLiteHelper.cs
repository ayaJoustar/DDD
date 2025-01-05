using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Entities;

namespace DDD.WinForm.Common
{
    internal static class SQLiteHelper
    {

        internal const  string ConnectionString = @"Data Source =E:\Program Files (x86)\SQLite\DDD\DDD.db;version=3;";

        internal static IReadOnlyList<T> Query<T>(string sql,Func<SQLiteDataReader,T>createEntity)
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
                        result.Add(createEntity(reader));
                    }
                }
            }
            return result;
        }

        internal static T QuerySingle<T>(string sql,
                                        SQLiteParameter[] parameters,
                                        Func<SQLiteDataReader, T> createEntity,                                        
                                        T nullEntity)
        {

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if(parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       return createEntity(reader);
                    }
                }
            }
            return nullEntity;
        }

        internal static void Excecute(string insert, string update, SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(update, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                if(command.ExecuteNonQuery() < 1)
                {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Excecute(string sql, SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();
 
            }
        }
    }
}
