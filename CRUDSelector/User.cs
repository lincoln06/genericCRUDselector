using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSelector
{
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
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
