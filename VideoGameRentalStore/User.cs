using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoGameRentalStore
{
    class User
    {
        public string userID { get; private set; }
        public string userPassword { get; private set; }
        public string userName { get; private set; }
        public string userPhone { get; private set; }
        public string userAddress { get; private set; }
        public string userEmail { get; private set; }        
        public User(string id, string password, string name, string phone, string address, string email)
        {
            userID = id;
            userPassword = password;
            userName = name;
            userPhone = phone;
            userAddress = address;
            userEmail = email;            
        }
    }
}
