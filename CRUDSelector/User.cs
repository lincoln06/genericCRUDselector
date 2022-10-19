using MongoDB.Bson.Serialization.Attributes;

namespace CRUDSelector
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonElement]
        public string FirstName { get; }
        [BsonElement]
        public string LastName { get; }
        [BsonElement]
        public string Email { get; }
        [BsonElement]
        public string Password { get; }
        public User(string firstName, string lastName, string email, string password)
        {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Password = Coder.Encrypt(password,email);
        }
    }
}