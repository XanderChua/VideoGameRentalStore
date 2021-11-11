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
    [RoutePrefix("api/UserManager")]
    public class UserController : ApiController
    {
        private string readUser;
        public Dictionary<string, User> storeUsers = new Dictionary<string, User>();

        private void Initialize()
        {
            readUser = File.ReadAllText("StoreUser.json");
            storeUsers = JsonConvert.DeserializeObject<Dictionary<string, User>>(readUser);
        }

        private void Update()
        {
            string userJson = JsonConvert.SerializeObject(storeUsers);
            File.WriteAllText("StoreUser.json", userJson);//run VS as administrator
        }

        [HttpGet]
        [Route("")]
        public Dictionary<string, User> GetAll()
        {
            Initialize();
            return storeUsers;
        }

        [HttpGet]
        [Route("{id}")]
        public KeyValuePair<string, User> Get(string id)
        {
            Initialize();
            return storeUsers.Where(x => x.Key.Contains(id)).FirstOrDefault();
        }
    }
}