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
    [RoutePrefix("api/StoreStaffManager")]
    public class StoreStaffController : ApiController
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
            string storeUserJson = JsonConvert.SerializeObject(storeUsers);
            File.WriteAllText("StoreUser.json", storeUserJson);
        }

        [HttpGet]
        [Route("")]
        public Dictionary<string, StoreStaff> GetAll()
        {
            Initialize();
            return storeStaffs;
        }

        [HttpGet]
        [Route("{id}")]
        public KeyValuePair<string, StoreStaff> Get(string id)
        {
            Initialize();
            return storeStaffs.Where(x => x.Key.Contains(id)).FirstOrDefault();
        }

        //[HttpPost]
        //[Route("AddStaff")]
        //public Dictionary<string, StoreStaff> AddStaff(string id, string password, string name, string phone, string address, string email)
        //{
        //    Initialize();
        //    storeStaffs.Add(id, new StoreStaff(id, password, name, phone, address, email));
        //    Update();
        //    return storeStaffs;
        //}

        [HttpPost]
        [Route("AddUser")]
        public Dictionary<string, User> AddUser(string id, string password, string name, string phone, string address, string email)
        {
            Initialize();
            storeUsers.Add(id, new User(id, password, name, phone, address, email));
            Update();
            return storeUsers;
        }

        [HttpGet]
        [Route("AvailableGames")]
        public IDictionary<string, Games> GetAvailableGames()
        {
            Initialize();
            IDictionary<string, Games> gameDict = new Dictionary<string, Games>();
            foreach(KeyValuePair<string,Games> item in storeGames.Where(x => x.Value.rentedStatus == "Not Rented"))
            {
                gameDict.Add(item);
            }
            return gameDict;
        }

        //[HttpGet]
        //[Route("SearchUser")]
        //public string SearchUserByGames(string gameid)
        //{
        //    Initialize();
        //    return storeGames[gameid].rentedBy.ToString();
        //} 

        [HttpGet]
        [Route("SearchUser")]
        public IDictionary<string, Games> SearchUserByGamesRented(string gameid)
        {
            Initialize();
            IDictionary<string, Games> gameDict = new Dictionary<string, Games>();
            foreach (KeyValuePair<string, Games> item in storeGames.Where(x => x.Key == gameid))
            {
                gameDict.Add(item);
            }
            return gameDict;
        }

        [HttpGet]
        [Route("SearchGames")]
        public IDictionary<string, Games> SearchGamesRentedByUser(string userid)
        {
            Initialize();
            IDictionary<string, Games> gameDict = new Dictionary<string, Games>();
            foreach (KeyValuePair<string, Games> item in storeGames.Where(x => x.Value.rentedBy == userid))
            {
                gameDict.Add(item);
            }
            return gameDict;
        }

        [HttpPatch]
        [Route("UpdatePassword")]
        public Dictionary<string, StoreStaff> UpdatePassword(string id, string password)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if (existingStaff == null)
            {
                return null;
            }
            else
            {
                storeStaffs.Remove(id);
                existingStaff.UpdateName(password);
                storeStaffs.Add(id, existingStaff);
                Update();
            }
            return storeStaffs;
        }

        [HttpPatch]
        [Route("UpdateName")]
        public Dictionary<string, StoreStaff> UpdateName(string id, string name)
        {
            Initialize();
            StoreStaff existingStaff= storeStaffs[id];
            if (existingStaff == null)
            {
                return null;
            }               
            else
            {
                storeStaffs.Remove(id);
                existingStaff.UpdateName(name);
                storeStaffs.Add(id, existingStaff);
                Update();
            }
            return storeStaffs;
        }

        [HttpPatch]
        [Route("UpdatePhone")]
        public Dictionary<string, StoreStaff> UpdatePhone(string id, string phone)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if (existingStaff == null)
            {
                return null;
            }
            else
            {
                storeStaffs.Remove(id);
                existingStaff.UpdatePhone(phone);
                storeStaffs.Add(id, existingStaff);
                Update();
            }
            return storeStaffs;
        }

        [HttpPatch]
        [Route("UpdateAddress")]
        public Dictionary<string, StoreStaff> UpdateAddress(string id, string address)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if (existingStaff == null)
            {
                return null;
            }
            else
            {
                storeStaffs.Remove(id);
                existingStaff.UpdateAddress(address);
                storeStaffs.Add(id, existingStaff);
                Update();
            }
            return storeStaffs;
        }

        [HttpPatch]
        [Route("UpdateEmail")]
        public Dictionary<string, StoreStaff> UpdateEmail(string id, string email)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if (existingStaff == null)
            {
                return null;
            }
            else
            {
                storeStaffs.Remove(id);
                existingStaff.UpdateEmail(email);
                storeStaffs.Add(id, existingStaff);
                Update();
            }
            return storeStaffs;
        }

        [HttpDelete]
        [Route("DeleteStaff/{id}")]
        public Dictionary<string, StoreStaff> Delete(string id)
        {
            Initialize();
            StoreStaff existingStaff = storeStaffs[id];
            if (existingStaff != null)
            {
                storeStaffs.Remove(id);
                Update();
            }          
            return storeStaffs;
        }
    }
}
