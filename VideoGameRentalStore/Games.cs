using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameRentalStore
{
    class Games
    {
        public string gamesID { get; private set; }
        public string gamesName { get; private set; }
        public string gameRentPrice { get; private set; }
        public string rentedStatus { get; set; }
        public string rentedBy { get; set; }
        public string rentedDate { get; set; }
        public string returnByDate { get; set; }
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
