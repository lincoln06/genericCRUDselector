using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSelector
{
    class MongoCRUD:ICrud
    {
        IMongoCollection<User> collection = new MongoClient().GetDatabase("Service").GetCollection<User>("Users");
        public bool FindEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            if (collection.Find(filter).ToList().Count == 0) return false;
            return true;
        }
        public void Register(User user)
        {
            collection.InsertOne(user);
        }
        public User Login(string email,string password) 
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq("Email", email),
                Builders<User>.Filter.Eq("Password", password));
            try {
            var record = collection.Find(filter).ToList();
                return (User)record[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
