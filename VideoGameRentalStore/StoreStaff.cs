using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoGameRentalStore
{
    class StoreStaff
    {
        public string staffID { get; private set; }
        public string staffPassword { get; private set; }
        public string staffName { get; private set; }
        public string staffPhone { get; private set; }
        public string staffAddress { get; private set; }
        public string staffEmail { get; private set; }   
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
