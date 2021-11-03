using System;
using System.Collections.Generic;
using System.IO;

namespace VideoGameRentalStore
{
    public class Games
    {
        public string gamesID { get; private set; }
        public string gamesName { get; private set; }
        public string gameRentPrice { get; private set; }
        public string rentedStatus { get; set; }
        public string rentedBy { get; set; }
        public string rentedDate { get; set; }
        public string returnByDate { get; set; }
        private Dictionary<string, Games> _gamesDict;
        public Dictionary<string, Games> GamesDictObj
        {
            get
            {
                if (_gamesDict == null)
                {
                    _gamesDict = new Dictionary<string, Games>();
                }
                return _gamesDict;
            }
            set
            {
                _gamesDict = value;
            }
        }
        public Games()
        {
                FileStream fsGames = new FileStream("GamesDetails.txt", FileMode.OpenOrCreate, FileAccess.Read);
                fsGames.Seek(0, SeekOrigin.Begin);
                StreamReader srGames = new StreamReader(fsGames);
                string strGames = srGames.ReadLine();
                while (!string.IsNullOrWhiteSpace(strGames))
                {
                    var strArr = strGames.Split(',');
                    var games = new Games(strArr[0], strArr[1], strArr[2], strArr[3], strArr[4], strArr[5], strArr[6]);
                    if (!GamesDictObj.ContainsKey(strArr[0]))
                    {
                        GamesDictObj.Add(strArr[0], games);
                    }
                    strGames = srGames.ReadLine();
                }
                srGames.Close();
                fsGames.Close();
            

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
        public void UpdateGames()
        {
            FileStream fsGames = new FileStream("GamesDetails.txt", FileMode.Truncate, FileAccess.Write);
            StreamWriter swGames = new StreamWriter(fsGames);
            foreach (var games in GamesDictObj)
            {
                swGames.WriteLine(games.Key + "," + games.Value.gamesName +
                    "," + games.Value.gameRentPrice + "," + games.Value.rentedStatus +
                    "," + games.Value.rentedBy + "," + games.Value.rentedDate +
                    "," + games.Value.returnByDate);
            }
            swGames.Flush();
            swGames.Close();
            fsGames.Close();
        }
    }
}