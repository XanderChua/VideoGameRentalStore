using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoGameRentalStore
{
    class StoreManager
    {
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
        private List<double> _earnedList;
        public List<double> EarnedListObj
        {
            get
            {
                if (_earnedList == null)
                {
                    _earnedList = new List<double>();
                }
                return _earnedList;
            }
            set
            {
                _earnedList = value;
            }
        }
        public StoreManager()
        {
            try
            {
                FileStream fsStaff = new FileStream("StaffDetails.txt", FileMode.OpenOrCreate, FileAccess.Read);
                fsStaff.Seek(0, SeekOrigin.Begin);
                StreamReader srStaff = new StreamReader(fsStaff);
                string strStaff = srStaff.ReadLine().ToString();
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
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught! Please check textfile. " + ex.Message);
            }

            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught! Please check textfile. " + ex.Message);
            }

            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught! Please check textfile. " + ex.Message);
            }

            try
            {
                FileStream fsEarned = new FileStream("EarnedTotal.txt", FileMode.OpenOrCreate, FileAccess.Read);
                fsEarned.Seek(0, SeekOrigin.Begin);
                StreamReader srEarned = new StreamReader(fsEarned);
                string strEarned = srEarned.ReadLine();
                while (!string.IsNullOrWhiteSpace(strEarned))
                {
                    double strEarnedDouble = Double.Parse(strEarned);
                    if (!EarnedListObj.Contains(strEarnedDouble))
                    {
                        EarnedListObj.Add(strEarnedDouble);
                    }
                    strEarned = srEarned.ReadLine();
                }
                srEarned.Close();
                fsEarned.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught! Please check textfile. " + ex.Message);
            }
        }
        public void PerformOperationsStoreManager(DateTime dateTime)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--Manage Store Page--");
                Console.WriteLine("1. Add Store Staff");
                Console.WriteLine("2. Add Games");
                Console.WriteLine("3. List Store Staffs");
                Console.WriteLine("4. List Users");
                Console.WriteLine("5. Games Available");
                Console.WriteLine("6. Games Rented");
                Console.WriteLine("7. Check Overdued Games");
                Console.WriteLine("8. Check Total Earned");
                Console.WriteLine("9. Exit");
                try
                {
                    int inputStoreManagerOption = Int32.Parse(Console.ReadLine());
                    if (inputStoreManagerOption == 1)
                    {
                        Console.WriteLine("Create Staff ID:");
                        string inputStaffID = Console.ReadLine();
                        Console.WriteLine("Create Staff Password:");
                        string inputStaffPassword = Console.ReadLine();
                        Console.WriteLine("Create Staff Name:");
                        string inputStaffName = Console.ReadLine();
                        Console.WriteLine("Create Staff Phone Number:");
                        string inputStaffPhone = Console.ReadLine();
                        Console.WriteLine("Create Staff Address:");
                        string inputStaffEmail = Console.ReadLine();
                        Console.WriteLine("Create Staff Email:");
                        string inputStaffAddress = Console.ReadLine();
                        if (inputStaffPhone.Any(char.IsDigit))
                        {
                            StaffDictObj.Add(inputStaffID, new StoreStaff(inputStaffID, inputStaffPassword, inputStaffName, inputStaffPhone, inputStaffEmail, inputStaffAddress));
                            UpdateStaffs();
                            Console.WriteLine(inputStaffID + ", " + inputStaffName + " added!");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid phone number.");
                        }
                    }
                    else if (inputStoreManagerOption == 2)
                    {
                        Console.WriteLine("Create Games ID:");
                        string inputGamesID = Console.ReadLine();
                        Console.WriteLine("Create Games Name:");
                        string inputGamesName = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        string rentPrice = Console.ReadLine();
                        if (rentPrice.Any(char.IsDigit))
                        {                           
                            GamesDictObj.Add(inputGamesID, new Games(inputGamesID, inputGamesName, rentPrice, "Not Rented", null, null, null));
                            UpdateGames();
                            Console.WriteLine(inputGamesID + ", " + inputGamesName + " added!");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid price.");
                        }

                    }
                    else if (inputStoreManagerOption == 3)
                    {
                        foreach (var staff in StaffDictObj)
                        {
                            Console.WriteLine("Staff ID: " + staff.Key + " Staff Name: " + staff.Value.staffName +
                                "\nStaff Phone: " + staff.Value.staffPhone + " Staff Address: " + staff.Value.staffAddress +
                                "\nStaff Email: " + staff.Value.staffEmail);
                        }
                    }
                    else if (inputStoreManagerOption == 4)
                    {
                        foreach (var user in UserDictObj)
                        {
                            Console.WriteLine("User ID: " + user.Key + " User Name: " + user.Value.userName +
                                "\nUser Phone: " + user.Value.userPhone + " User Address: " + user.Value.userAddress +
                                "\nUser Email: " + user.Value.userEmail);
                        }
                    }
                    else if (inputStoreManagerOption == 5)
                    {
                        foreach (var game in GamesDictObj)
                        {
                            if (game.Value.rentedStatus == "Not Rented")
                            {
                                Console.WriteLine("Game ID: " + game.Key + "\nGame Name: " + game.Value.gamesName);
                            }
                        }
                    }
                    else if (inputStoreManagerOption == 6)
                    {
                        foreach (var rentedgame in GamesDictObj)
                        {
                            if (rentedgame.Value.rentedStatus == "Rented")
                            {
                                Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName);
                            }
                        }
                    }
                    else if (inputStoreManagerOption == 7)
                    {
                        Console.WriteLine("Overdued games:");
                        foreach (var games in GamesDictObj)
                        {
                            DateTime convertedReturnDate = DateTime.Parse(games.Value.returnByDate + " 12:00:00 AM");
                            double daysLate = ((dateTime - convertedReturnDate).TotalDays);
                            if (games.Value.returnByDate != "" && daysLate > 0)
                            {
                                Console.WriteLine("Game ID: " + games.Key + " Game Name: " + games.Value.gamesName + 
                                    "\nRented By: " + games.Value.rentedBy + " Return By: " + games.Value.returnByDate);
                            }
                        }
                    }
                    else if (inputStoreManagerOption == 8)
                    {
                        double earnedProfit = EarnedListObj.Sum();
                        Console.WriteLine("Current amount earned: $" + earnedProfit);
                    }
                    else if (inputStoreManagerOption == 9)
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter the correct option!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught! " + ex.Message);
                }
            }
        }
        public void PerformOperationsStoreStaff()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--Store Staff Page--");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Games Available");
                Console.WriteLine("3. Search User by Games Rented");
                Console.WriteLine("4. Search Games by Rented User");
                Console.WriteLine("5. Exit");
                try
                {
                    int inputStoreStaffOption = Int32.Parse(Console.ReadLine());
                    if (inputStoreStaffOption == 1)
                    {

                        Console.WriteLine("Create User ID:");
                        string inputUserID = Console.ReadLine();
                        Console.WriteLine("Create User Password:");
                        string inputUserPassword = Console.ReadLine();
                        Console.WriteLine("Create User Name:");
                        string inputUserName = Console.ReadLine();
                        Console.WriteLine("Create User Phone Number:");
                        string inputUserPhone = Console.ReadLine();
                        Console.WriteLine("Create User Address:");
                        string inputUserEmail = Console.ReadLine();
                        Console.WriteLine("Create User Email:");
                        string inputUserAddress = Console.ReadLine();

                        if (inputUserPhone.Any(char.IsDigit) && inputUserEmail.Contains("@"))
                        {
                            UserDictObj.Add(inputUserID, new User(inputUserID, inputUserPassword, inputUserName, inputUserPhone, inputUserEmail, inputUserAddress));
                            UpdateUser();
                            Console.WriteLine(inputUserID + ", " + inputUserName + " added!");
                        }
                        else if (!(inputUserPhone.Any(char.IsDigit)) && inputUserEmail.Contains("@"))
                        {
                            Console.WriteLine("Phone number is not valid.");
                        }
                        else if (inputUserPhone.Any(char.IsDigit) && !(inputUserEmail.Contains("@")))
                        {
                            Console.WriteLine("Email address is not valid.");
                        }
                        else
                        {
                            Console.WriteLine("Phone number and Email address are not valid.");
                        }
                    }
                    else if (inputStoreStaffOption == 2)
                    {
                        foreach (var game in GamesDictObj)
                        {
                            if (game.Value.rentedStatus == "Not Rented")
                            {
                                Console.WriteLine("Game ID: " + game.Key + "\nGame Name: " + game.Value.gamesName);
                            }
                        }
                    }
                    else if (inputStoreStaffOption == 3)
                    {
                        try
                        {
                            Console.WriteLine("Enter Game ID:");
                            string searchUserByGames = Console.ReadLine();
                            Console.WriteLine("User who rented " + searchUserByGames + ":");
                            foreach (var user in GamesDictObj)
                            {
                                if (user.Key == searchUserByGames)
                                {
                                    Console.WriteLine(user.Value.rentedBy);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception handled: " + ex.Message);
                        }                        
                    }
                    else if (inputStoreStaffOption == 4)
                    {
                        try
                        {
                            Console.WriteLine("Enter User ID:");
                            string searchGamesByUser = Console.ReadLine();
                            Console.WriteLine("Games rented by " + searchGamesByUser + ":");
                            foreach (var game in GamesDictObj)
                            {
                                if (game.Value.rentedBy == searchGamesByUser)
                                {
                                    Console.WriteLine(game.Key);
                                }
                            }
                        }                       
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception handled: " + ex.Message);
                        }   
                    }
                    else if (inputStoreStaffOption == 5)
                    {                        
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter the correct option!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught! " + ex.Message);
                }
            }
        }
        public void PerformOperationsUser(string id, DateTime dateTime)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--User Page--");
                Console.WriteLine("1. Rent Game");
                Console.WriteLine("2. Return Game");
                Console.WriteLine("3. List Rented Games");
                Console.WriteLine("4. Exit");
                try
                {
                    int inputStoreUser = Int32.Parse(Console.ReadLine());
                    if (inputStoreUser == 1)
                    {
                        Console.WriteLine("Enter game ID to rent:");
                        foreach (var game in GamesDictObj)
                        {
                            if (game.Value.rentedStatus == "Not Rented")
                            {
                                Console.WriteLine("Game ID: " + game.Key + "\nGame Name: " + game.Value.gamesName + " Price: " + game.Value.gameRentPrice);
                            }
                        }
                        string selectGameRent = Console.ReadLine();
                        GamesDictObj[selectGameRent].rentedStatus = "Rented";
                        GamesDictObj[selectGameRent].rentedBy = id;
                        GamesDictObj[selectGameRent].rentedDate = dateTime.ToString("dd/MM/yyyy");
                        GamesDictObj[selectGameRent].returnByDate = dateTime.AddDays(6).ToString("dd/MM/yyyy");
                        UpdateGames();
                        Console.WriteLine("Game ID: " + selectGameRent + " successfully rented!");
                    }
                    else if (inputStoreUser == 2)
                    {
                        Console.WriteLine("Enter game ID to return:");
                        foreach (var rentedgame in GamesDictObj)
                        {
                            if (rentedgame.Value.rentedStatus == "Rented" && rentedgame.Value.rentedBy == id)
                            {
                                Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName);
                            }
                        }
                        string selectGameReturn = Console.ReadLine();
                        GamesDictObj[selectGameReturn].rentedStatus = "Not Rented";
                        GamesDictObj[selectGameReturn].rentedBy = "";
                        DateTime convertedReturnDate = Convert.ToDateTime(GamesDictObj[selectGameReturn].returnByDate);
                        double daysLate = ((dateTime - convertedReturnDate).TotalDays);
                        if (daysLate > 0)
                        {
                            double gamePrice = Double.Parse(GamesDictObj[selectGameReturn].gameRentPrice);
                            double fine = daysLate * (gamePrice * 0.5);
                            EarnedListObj.Add(fine + gamePrice);
                            Console.WriteLine("$" + (fine + gamePrice) + " paid.");
                            Console.WriteLine("You paid an extra $" + fine + " fine for returning " + daysLate + " days late.");
                        }
                        else
                        {
                            double gamePrice = Double.Parse(GamesDictObj[selectGameReturn].gameRentPrice);
                            EarnedListObj.Add(gamePrice);
                        }
                        GamesDictObj[selectGameReturn].rentedDate = "";
                        GamesDictObj[selectGameReturn].returnByDate = "";
                        UpdateEarned();
                        UpdateGames();
                        Console.WriteLine("Game ID: " + selectGameReturn + " successfully returned!");
                        Console.WriteLine(daysLate);
                    }
                    else if (inputStoreUser == 3)
                    {
                        foreach (var rentedgame in GamesDictObj)
                        {
                            if (rentedgame.Value.rentedBy == id)
                            {
                                Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName + " Return By: " + rentedgame.Value.returnByDate);
                            }
                        }
                    }
                    else if (inputStoreUser == 4)
                    {
                        loop = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught! " + ex.Message);
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
        public void UpdateGames()
        {
            FileStream fsGames = new FileStream("GamesDetails.txt", FileMode.OpenOrCreate, FileAccess.Write);
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
        public void UpdateEarned()
        {
            FileStream fsEarned = new FileStream("EarnedTotal.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swEarned = new StreamWriter(fsEarned);
            foreach (var earned in EarnedListObj)
            {
                swEarned.WriteLine(earned);
            }
            swEarned.Close();
            fsEarned.Close();
        }
    }
}
