using Microsoft.Data.Sqlite;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace CRUDSelector
{
    public class SqliteCRUD:ICrud
    {
        private SqliteConnection connection = new SqliteConnection("Data Source=Service.db");
        
        
        public User Login(string email, string password)
        {
            string a1=String.Empty;
            string a2=String.Empty;
            string a3=String.Empty;
            string a4 = String.Empty;
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"select * from Users where Email='"+email+"' and Password='"+password+"'";
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
            MessageBox.Show(user.Password);
            command.CommandText = @"insert into Users(FirstName,LastName,Email,Password) values('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password + "')";
            command.ExecuteNonQuery();
            connection.Close();
        }
        
    }
}
