using System;
using System.Linq;

namespace VideoGameRentalStore
{
    public class Program
    {
        private readonly IConsoleIO ConsoleIO;
        public Program(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Today's date: " + dt.ToString("dd/MM/yyyy"));
                Console.WriteLine("--Game Rental Store--");
                Console.WriteLine("Welcome! Please input an option.");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Set Date");
                Console.WriteLine("3. Exit");
                try
                {
                    int input = Int32.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        Console.WriteLine("Enter ID to login:");
                        string inputID = Console.ReadLine();
                        Console.WriteLine("Enter Password to login:");
                        string password = Console.ReadLine();
                        if (inputID == "000" && password == "super")
                        {
                            PerformOperationsStoreManager(dt);
                        }
                        else if (ValidateCredentialsStaff(inputID, password) == true)
                        {
                            PerformOperationsStoreStaff(inputID);
                        }
                        else if (ValidateCredentialsUser(inputID, password) == true)
                        {
                            PerformOperationsUser(inputID, dt);
                        }
                        else
                        {
                            Console.WriteLine("User ID or password is incorrect");
                        }
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("Enter date in dd/mm/yyyy format:");
                        var date = Console.ReadLine();
                        var isValidDate = DateTime.TryParse(date, out dt);
                        if (isValidDate)
                        {
                            Console.WriteLine(dt.ToString("dd/MM/yyyy") + " has been set to today's date.");
                        }
                        else
                        {
                            Console.WriteLine(date + " is not a valid date string.");
                        }
                    }
                    else if (input == 3)
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
        public void LoginUser()
        {
            ConsoleIO.WriteLine("Enter ID to login:");
            string inputID = ConsoleIO.ReadLine();
            ConsoleIO.WriteLine("Enter Password to login:");
            string password = ConsoleIO.ReadLine();
            ConsoleIO.WriteLine("Login test success!");
        }
        public static bool ValidateCredentialsStaff(string id, string password)
        {
            StoreStaff storeStaff = new StoreStaff();
            return storeStaff.StaffDictObj.Any(entry => entry.Key == id && entry.Value.staffPassword == password);
        }
        public static bool ValidateCredentialsUser(string id, string password)
        {
            User user = new User();
            return user.UserDictObj.Any(entry => entry.Key == id && entry.Value.userPassword == password);
        }
        public static void PerformOperationsStoreManager(DateTime dateTime)
        {
            StoreManager storeManager = new StoreManager();
            StoreStaff storeStaff = new StoreStaff();
            Games games = new Games();
            User user = new User();
            Earned earned = new Earned();
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
                        string inputStaffAddress = Console.ReadLine();
                        Console.WriteLine("Create Staff Email:");
                        string inputStaffEmail = Console.ReadLine();
                        storeManager.AddStoreStaff(storeStaff, inputStaffID, inputStaffPassword, inputStaffName, inputStaffPhone, inputStaffAddress, inputStaffEmail);
                    }
                    else if (inputStoreManagerOption == 2)
                    {
                        Console.WriteLine("Create Games ID:");
                        string inputGamesID = Console.ReadLine();
                        Console.WriteLine("Create Games Name:");
                        string inputGamesName = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        string rentPrice = Console.ReadLine();
                        storeManager.AddGames(games, inputGamesID, inputGamesName, rentPrice);
                    }
                    else if (inputStoreManagerOption == 3)
                    {
                        storeManager.ListStaff(storeStaff);
                        Console.WriteLine("\n");
                    }
                    else if (inputStoreManagerOption == 4)
                    {
                        storeManager.ListUser(user);
                        Console.WriteLine("\n");
                    }
                    else if (inputStoreManagerOption == 5)
                    {
                        storeManager.GamesAvailable(games);
                        Console.WriteLine("\n");
                    }
                    else if (inputStoreManagerOption == 6)
                    {
                        storeManager.GamesRented(games);
                        Console.WriteLine("\n");
                    }
                    else if (inputStoreManagerOption == 7)
                    {
                        storeManager.OverduedGames(dateTime, games);
                        Console.WriteLine("\n");
                    }
                    else if (inputStoreManagerOption == 8)
                    {
                        storeManager.TotalEarned(earned);
                        Console.WriteLine("\n");
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
        public static void PerformOperationsStoreStaff(string id)
        {
            StoreStaff storeStaff = new StoreStaff();
            Games games = new Games();
            User user = new User();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Welcome " + id + ", " + storeStaff.StaffDictObj[id].staffName);
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
                        storeStaff.AddUser(user, inputUserID, inputUserPassword, inputUserName, inputUserPhone, inputUserAddress, inputUserEmail);
                    }
                    else if (inputStoreStaffOption == 2)
                    {
                        storeStaff.GamesAvailable(games);
                    }
                    else if (inputStoreStaffOption == 3)
                    {
                        Console.WriteLine("Enter Game ID:");
                        string searchUserByGames = Console.ReadLine();
                        storeStaff.SearchUserByGames(games, searchUserByGames);
                    }
                    else if (inputStoreStaffOption == 4)
                    {
                        Console.WriteLine("Enter User ID:");
                        string searchGamesByUser = Console.ReadLine();
                        storeStaff.SearchGamesByUser(games, searchGamesByUser);
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
        public static void PerformOperationsUser(string id, DateTime dateTime)
        {
            Games games = new Games();
            User user = new User();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Welcome " + id + ", " + user.UserDictObj[id].userName);
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
                        foreach (var game in games.GamesDictObj)
                        {
                            if (game.Value.rentedStatus == "Not Rented")
                            {
                                Console.WriteLine("Game ID: " + game.Key + "\nGame Name: " + game.Value.gamesName + " Price: " + game.Value.gameRentPrice);
                            }
                        }
                        string selectGameRent = Console.ReadLine();
                        user.RentGames(id, dateTime, selectGameRent);
                    }
                    else if (inputStoreUser == 2)
                    {
                        Console.WriteLine("Enter game ID to return:");
                        foreach (var rentedgame in games.GamesDictObj)
                        {
                            if (rentedgame.Value.rentedStatus == "Rented" && rentedgame.Value.rentedBy == id)
                            {
                                Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName);
                            }
                        }
                        string selectGameReturn = Console.ReadLine();
                        user.ReturnGames(id, dateTime, selectGameReturn);
                    }
                    else if (inputStoreUser == 3)
                    {
                        user.ListRentedGames(id);
                        Console.WriteLine("\n");
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

    }
}