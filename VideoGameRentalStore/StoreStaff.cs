using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VideoGameRentalStore
{
    public class StoreStaff
    {
        public string staffID { get; private set; }
        public string staffPassword { get; private set; }
        public string staffName { get; private set; }
        public string staffPhone { get; private set; }
        public string staffAddress { get; private set; }
        public string staffEmail { get; private set; }
        private Dictionary<string, StoreStaff> _staffDict;
        public Dictionary<string, StoreStaff> StaffDictObj
        {
            get
            {
                if (_staffDict == null)
                {
                    _staffDict = new Dictionary<string, StoreStaff>();
                }
                return _staffDict;
            }
            set
            {
                _staffDict = value;
            }
        }
        public StoreStaff()
        {
            FileStream fsStaff = new FileStream("StaffDetails.txt", FileMode.OpenOrCreate, FileAccess.Read);
            fsStaff.Seek(0, SeekOrigin.Begin);
            StreamReader srStaff = new StreamReader(fsStaff);
            string strStaff = srStaff.ReadLine();
            while (!string.IsNullOrWhiteSpace(strStaff))
            {
                var strArr = strStaff.Split(',');
                var staff = new StoreStaff(strArr[0], strArr[1], strArr[2], strArr[3], strArr[4], strArr[5]);
                if (!StaffDictObj.ContainsKey(strArr[0]))
                {
                    StaffDictObj.Add(strArr[0], staff);
                }
                strStaff = srStaff.ReadLine();
            }
            srStaff.Close();
            fsStaff.Close();
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
        public void AddUser(User user, string inputUserID, string inputUserPassword, string inputUserName, string inputUserPhone, string inputUserAddress, string inputUserEmail)
        {
            try
            {
                if (inputUserPhone.Any(char.IsDigit))
                {
                    user.UserDictObj.Add(inputUserID, new User(inputUserID, inputUserPassword, inputUserName, inputUserPhone, inputUserAddress, inputUserEmail));
                    user.UpdateUser();
                    Console.WriteLine(inputUserID + ", " + inputUserName + " added!");
                }
                else
                {
                    Console.WriteLine("Please enter a valid phone number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception handled. " + ex.Message);
            }

        }
        public void GamesAvailable(Games games)
        {
            foreach (var game in games.GamesDictObj)
            {
                if (game.Value.rentedStatus == "Not Rented")
                {
                    Console.WriteLine("Game ID: " + game.Key + "\nGame Name: " + game.Value.gamesName);
                }
            }
        }
        public void SearchUserByGames(Games games, string searchUserByGames)
        {
            Console.WriteLine("User who rented " + searchUserByGames + ": ");
            foreach (var user in games.GamesDictObj)
            {
                if (user.Key == searchUserByGames)
                {
                    Console.WriteLine(user.Value.rentedBy);
                }
            }
        }
        public void SearchGamesByUser(Games games, string searchGamesByUser)
        {
            Console.WriteLine("Games rented by " + searchGamesByUser + ": ");
            foreach (var game in games.GamesDictObj)
            {
                if (game.Value.rentedBy == searchGamesByUser)
                {
                    Console.WriteLine(game.Key);
                }
            }
        }
        public void UpdateStaffs()
        {
            FileStream fsStaff = new FileStream("StaffDetails.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swStaff = new StreamWriter(fsStaff);
            foreach (var staff in StaffDictObj)
            {
                swStaff.WriteLine(staff.Key + "," + staff.Value.staffPassword +
                    "," + staff.Value.staffName + "," + staff.Value.staffPhone +
                    "," + staff.Value.staffAddress + "," + staff.Value.staffEmail);
            }
            swStaff.Close();
            fsStaff.Close();
        }
    }
}