using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Games
    {
        public string gamesID { get; set; }
        public string gamesName { get; set; }
        public string gameRentPrice { get; set; }
        public string rentedStatus { get; set; }
        public string rentedBy { get; set; }
        public string rentedDate { get; set; }
        public string returnByDate { get; set; }
        public Games()
        {

        }
        public Games(string id, string name, string price, string status, string rent, string rd, string rbd)
        {
            gamesID = id;
            gamesName = name;
            gameRentPrice = price;
            rentedStatus = status;
            rentedBy = rent;
            rentedDate = rd;
            returnByDate = rbd;
        }
    }
}