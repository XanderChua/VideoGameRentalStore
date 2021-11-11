using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class AuthenticationController : ApiController
    {
        private string readStaff;
        public Dictionary<string, StoreStaff> storeStaffs = new Dictionary<string, StoreStaff>();
        private string readUser;
        public Dictionary<string, User> storeUsers = new Dictionary<string, User>();

        private void Initialize()
        {
            readStaff = File.ReadAllText("StoreStaff.json");
            storeStaffs = JsonConvert.DeserializeObject<Dictionary<string, StoreStaff>>(readStaff);
            readUser = File.ReadAllText("StoreUser.json");
            storeUsers = JsonConvert.DeserializeObject<Dictionary<string, User>>(readUser);
        }

        [HttpGet]
        [Route("VerifyStaff")]
        public StoreStaff LoginStaff(string id, string password)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if ((existingStaff.staffID == id) && (existingStaff.staffPassword == password))
            {
                return storeStaffs[id];
            }
            else
            {
                return null;
            }          
        }

        [HttpGet]
        [Route("VerifyUser")]
        public User LoginUser(string id, string password)
        {
            Initialize();
            User existingUser = storeUsers[id];
            if ((existingUser.userID == id) && (existingUser.userPassword == password))
            {
                return storeUsers[id];
            }
            else
            {
                return null;
            }
        }
    }
}
