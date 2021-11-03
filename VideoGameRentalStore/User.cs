using System;
using System.Collections.Generic;
using System.IO;

namespace VideoGameRentalStore
{
    public class User
    {
        Games games = new Games();
        Earned earned = new Earned();
        public string userID { get; private set; }
        public string userPassword { get; private set; }
        public string userName { get; private set; }
        public string userPhone { get; private set; }
        public string userAddress { get; private set; }
        public string userEmail { get; private set; }
        private Dictionary<string, User> _userDict;
        public Dictionary<string, User> UserDictObj
        {
            get
            {
                if (_userDict == null)
                {
                    _userDict = new Dictionary<string, User>();
                }
                return _userDict;
            }
            set
            {
                _userDict = value;
            }
        }
        public User()
        {
            FileStream fsUser = new FileStream("UserDetails.txt", FileMode.OpenOrCreate, FileAccess.Read);
            fsUser.Seek(0, SeekOrigin.Begin);
            StreamReader srUser = new StreamReader(fsUser);
            string strUser = srUser.ReadLine();
            while (!string.IsNullOrWhiteSpace(strUser))
            {
                var strArr = strUser.Split(',');
                var user = new User(strArr[0], strArr[1], strArr[2], strArr[3], strArr[4], strArr[5]);
                if (!UserDictObj.ContainsKey(strArr[0]))
                {
                    UserDictObj.Add(strArr[0], user);
                }
                strUser = srUser.ReadLine();
            }
            srUser.Close();
            fsUser.Close();
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
        public void RentGames(string id, DateTime dateTime, string selectGameRent)
        {
            games.GamesDictObj[selectGameRent].rentedStatus = "Rented";
            games.GamesDictObj[selectGameRent].rentedBy = id;
            games.GamesDictObj[selectGameRent].rentedDate = dateTime.ToString("dd/MM/yyyy");
            games.GamesDictObj[selectGameRent].returnByDate = dateTime.AddDays(6).ToString("dd/MM/yyyy");
            games.UpdateGames();
            Console.WriteLine("Game ID: " + selectGameRent + " successfully rented!");
        }
        public void ReturnGames(string id, DateTime dateTime, string selectGameReturn)
        {
            games.GamesDictObj[selectGameReturn].rentedStatus = "Not Rented";
            games.GamesDictObj[selectGameReturn].rentedBy = "";
            DateTime convertedReturnDate = Convert.ToDateTime(games.GamesDictObj[selectGameReturn].returnByDate);
            double daysLate = ((dateTime - convertedReturnDate).TotalDays);
            if (daysLate > 0)
            {
                double gamePrice = Double.Parse(games.GamesDictObj[selectGameReturn].gameRentPrice);
                double fine = daysLate * (gamePrice * 0.5);
                earned.EarnedListObj.Add(fine + gamePrice);
                Console.WriteLine("$" + (fine + gamePrice) + " paid.");
                Console.WriteLine("You paid an extra $" + fine + " fine for returning " + daysLate + " days late.");
            }
            else
            {
                double gamePrice = Double.Parse(games.GamesDictObj[selectGameReturn].gameRentPrice);
                earned.EarnedListObj.Add(gamePrice);
                Console.WriteLine("$" + (gamePrice) + " paid.");
            }
            games.GamesDictObj[selectGameReturn].rentedDate = "";
            games.GamesDictObj[selectGameReturn].returnByDate = "";
            earned.UpdateEarned();
            games.UpdateGames();
            Console.WriteLine("Game ID: " + selectGameReturn + " successfully returned!");
        }
        public void ListRentedGames(string id)
        {
            foreach (var rentedgame in games.GamesDictObj)
            {
                if (rentedgame.Value.rentedBy == id)
                {
                    Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName + " Return By: " + rentedgame.Value.returnByDate);
                }
            }
        }
        public void UpdateUser()
        {
            FileStream fsUser = new FileStream("UserDetails.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swUser = new StreamWriter(fsUser);
            foreach (var user in UserDictObj)
            {
                swUser.WriteLine(user.Key + "," + user.Value.userPassword +
                    "," + user.Value.userName + "," + user.Value.userPhone +
                    "," + user.Value.userAddress + "," + user.Value.userEmail);
            }
            swUser.Close();
            fsUser.Close();
        }
    }
}