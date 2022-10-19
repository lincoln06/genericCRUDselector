using Microsoft.Data.Sqlite;
using System;
using System.Windows;

namespace CRUDSelector
{
    public class SqliteCRUD:ICrud
    {
        private SqliteConnection connection = new SqliteConnection("Data Source=Service.db");
        public User Login(string email, string password)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"select * from Users where Email='" + email + "' and Password='" + password + "'";
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return null;
            User user = new(reader.GetString(0),reader.GetString(1), reader.GetString(2),reader.GetString(3));
            connection.Close();
            return user;
        }
        public void Register(User user)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"insert into Users(FirstName,LastName,Email,Password) values('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password + "')";
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}