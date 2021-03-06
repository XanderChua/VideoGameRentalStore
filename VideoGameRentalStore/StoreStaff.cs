using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace VideoGameRentalStore
{
    public class StoreStaff
    {
        public string staffID { get; set; }
        public string staffPassword { get; set; }
        public string staffName { get; set; }
        public string staffPhone { get; set; }
        public string staffAddress { get; set; }
        public string staffEmail { get; set; }
        public StoreStaff()
        {

        }
        public StoreStaff(string id, string password, string name, string phone, string address, string email)
        {
            staffID = id;
            staffPassword = password;
            staffName = name;
            staffPhone = phone;
            staffAddress = address;
            staffEmail = email;
        }        
    }
}