using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        public string userID { get; set; }
        public string userPassword { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userAddress { get; set; }
        public string userEmail { get; set; }
        public User()
        {

        }
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