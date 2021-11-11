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
    [RoutePrefix("api/StoreManager")]
    public class StoreManagerController : ApiController
    {
        private string readStaff;
        public Dictionary<string, StoreStaff> storeStaffs = new Dictionary<string, StoreStaff>();
        private string readUser;
        public Dictionary<string, User> storeUsers = new Dictionary<string, User>();
        private string readGames;
        public Dictionary<string, Games> storeGames = new Dictionary<string, Games>();

        private void Initialize()
        {
            readStaff = File.ReadAllText("StoreStaff.json");
            storeStaffs = JsonConvert.DeserializeObject<Dictionary<string, StoreStaff>>(readStaff);
            readUser = File.ReadAllText("StoreUser.json");
            storeUsers = JsonConvert.DeserializeObject<Dictionary<string, User>>(readUser);
            readGames = File.ReadAllText("StoreGames.json");
            storeGames = JsonConvert.DeserializeObject<Dictionary<string, Games>>(readGames);
        }
        private void Update()//run VS as administrator
        {
            string storeStaffJson = JsonConvert.SerializeObject(storeStaffs);
            File.WriteAllText("StoreStaff.json", storeStaffJson);
            string storeGamesJson = JsonConvert.SerializeObject(storeGames);
            File.WriteAllText("StoreStaff.json", storeGamesJson);
        }

        [HttpPost]
        [Route("AddStaff")]
        public Dictionary<string, StoreStaff> AddStaff(string id, string password, string name, string phone, string address, string email)
        {
            Initialize();
            storeStaffs.Add(id, new StoreStaff(id, password, name, phone, address, email));
            Update();
            return storeStaffs;
        }

        [HttpPost]
        [Route("AddGames")]
        public Dictionary<string, Games> AddGames(string id, string name, string price, string rentstatus, string rentby, string rentdate, string returndate)
        {
            Initialize();
            storeGames.Add(id, new Games(id, name, price, rentstatus, rentby, rentdate, returndate));
            Update();
            return storeGames;
        }

        [HttpGet]
        [Route("ListStaff")]
        public Dictionary<string, StoreStaff> GetAllStaff()
        {
            Initialize();
            return storeStaffs;
        }

        [HttpGet]
        [Route("ListUser")]
        public Dictionary<string, User> GetAllUser()
        {
            Initialize();
            return storeUsers;
        }

        [HttpGet]
        [Route("ListGames")]
        public Dictionary<string, Games> GetAllGames()
        {
            Initialize();
            return storeGames;
        }

        //GamesRented
        //OverduedGames
        //TotalEarned
    }
}
