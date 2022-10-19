using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSelector
{
    public interface ICrud
    {
        public abstract User Login(string email, string password);

        public abstract void Register(User user);
       
    }
}
