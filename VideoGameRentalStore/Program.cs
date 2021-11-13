using System;
using System.Collections.Generic;
using System.IO;
using VideoGameRental.Common.DTO;
using VideoGameRentalStore.Interfaces;
using VideoGameRentalStore.ViewModel;

namespace VideoGameRentalStore
{
    public class Program
    {
        private readonly IConsoleIO ConsoleIO;
        private static IVideoGameRentalViewModel vm;
        public Program(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        static void Main(string[] args)
        {
            vm = new VideoGameRentalViewModel();
            vm.Initialize();
            string readUser = File.ReadAllText("StoreUser.json");
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
                            PerformOperationsvm(dt);                          
                        }
                        else if (vm.ValidateStaff(inputID, password) == true)
                        {
                            PerformOperationsStoreStaff(inputID);                           
                        }
                        else if (vm.ValidateUser(inputID, password) == true)
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

        public static void PerformOperationsvm(DateTime dateTime)
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
                    int inputvmOption = Int32.Parse(Console.ReadLine());
                    if (inputvmOption == 1)
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
                        vm.AddStaff(inputStaffID, inputStaffPassword, inputStaffName, inputStaffPhone, inputStaffAddress, inputStaffEmail);
                    }
                    else if (inputvmOption == 2)
                    {
                        Console.WriteLine("Create Games ID:");
                        string inputGamesID = Console.ReadLine();
                        Console.WriteLine("Create Games Name:");
                        string inputGamesName = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        string rentPrice = Console.ReadLine();
                        vm.AddGames(inputGamesID, inputGamesName, rentPrice);
                    }
                    else if (inputvmOption == 3)
                    {
                        vm.ListStaff();
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 4)
                    {
                        vm.ListUser();
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 5)
                    {
                        vm.GamesAvailable();
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 6)
                    {
                        vm.RentedGames();
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 7)
                    {
                        vm.OverduedGames(dateTime);
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 8)
                    {
                        vm.TotalEarned();
                        Console.WriteLine("\n");
                    }
                    else if (inputvmOption == 9)
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
            bool loop = true;
            ICollection<StoreStaffDTO> staffCollection = vm.ListStaff();
            while (loop)
            {
                foreach (var name in staffCollection)
                {
                    if (name.staffID == id)
                    {
                        Console.WriteLine("Welcome " + name.staffID + ", " + name.staffName);
                    }
                }
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
                        vm.AddUser(inputUserID, inputUserPassword, inputUserName, inputUserPhone, inputUserAddress, inputUserEmail);
                    }
                    else if (inputStoreStaffOption == 2)
                    {
                        vm.GamesAvailable();
                    }
                    else if (inputStoreStaffOption == 3)
                    {
                        Console.WriteLine("Enter Game ID:");
                        string searchUserByGames = Console.ReadLine();
                        vm.SearchUser(searchUserByGames);
                    }
                    else if (inputStoreStaffOption == 4)
                    {
                        Console.WriteLine("Enter User ID:");
                        string searchGamesByUser = Console.ReadLine();
                        vm.SearchGame(searchGamesByUser);
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
            bool loop = true;
            ICollection<UserDTO> userCollection = vm.ListUser();
            while (loop)
            {
                foreach(var name in userCollection)
                {
                    if(name.userID == id)
                    {
                        Console.WriteLine("Welcome " + name.userID + ", " + name.userName);
                    }
                }               
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
                        ICollection<GamesDTO> gameCollection= vm.GamesAvailable();
                        foreach (var game in gameCollection)
                        {
                            if (game.rentedStatus == "Not Rented")
                            {
                                Console.WriteLine("Game ID: " + game.gamesID + "\nGame Name: " + game.gamesName + " Price: " + game.gameRentPrice);
                            }
                        }
                        string selectGameRent = Console.ReadLine();
                        vm.Rent(id, dateTime, selectGameRent);
                    }
                    else if (inputStoreUser == 2)
                    {
                        Console.WriteLine("Enter game ID to return:");
                        ICollection<GamesDTO> gameCollection = vm.RentedGames();
                        foreach (var rentedgame in gameCollection)
                        {
                            if (rentedgame.rentedStatus == "Rented" && rentedgame.rentedBy == id)
                            {
                                Console.WriteLine("Game ID: " + rentedgame.gamesID + "\nGame Name: " + rentedgame.gamesName);
                            }
                        }
                        string selectGameReturn = Console.ReadLine();
                        vm.Return(id, dateTime, selectGameReturn);
                    }
                    else if (inputStoreUser == 3)
                    {
                        vm.ListRentedGames(id);
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