using System;
using System.Linq;

namespace VideoGameRentalStore
{
    public class StoreManager
    {       
        public void AddStoreStaff(StoreStaff storeStaff, string inputStaffID, string inputStaffPassword, string inputStaffName, string inputStaffPhone, string inputStaffAddress, string inputStaffEmail)
        {
            try
            {
                if (inputStaffPhone.Any(char.IsDigit))
                {
                    storeStaff.StaffDictObj.Add(inputStaffID, new StoreStaff(inputStaffID, inputStaffPassword, inputStaffName, inputStaffPhone, inputStaffAddress, inputStaffEmail));
                    storeStaff.UpdateStaffs();
                    Console.WriteLine(inputStaffID + ", " + inputStaffName + " added!");
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
        public void AddGames(Games games, string inputGamesID, string inputGamesName, string rentPrice)
        {
            try
            {
                if (rentPrice.Any(char.IsDigit))
                {
                    games.GamesDictObj.Add(inputGamesID, new Games(inputGamesID, inputGamesName, rentPrice, "Not Rented", null, null, null));
                    games.UpdateGames();
                    Console.WriteLine(inputGamesID + ", " + inputGamesName + " added!");
                }
                else
                {
                    Console.WriteLine("Please enter a valid price.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception handled. " + ex.Message);
            }
        }
        public void ListStaff(StoreStaff storeStaff)
        {
            Console.WriteLine("Store Staffs:");
            foreach (var staff in storeStaff.StaffDictObj)
            {
                Console.WriteLine("Staff ID: " + staff.Key + " Staff Name: " + staff.Value.staffName +
                    "\nStaff Phone: " + staff.Value.staffPhone + " Staff Address: " + staff.Value.staffAddress +
                    "\nStaff Email: " + staff.Value.staffEmail);
            }
        }
        public void ListUser(User user)
        {
            Console.WriteLine("Users:");
            foreach (var userList in user.UserDictObj)
            {
                Console.WriteLine("User ID: " + userList.Key + " User Name: " + userList.Value.userName +
                    "\nUser Phone: " + userList.Value.userPhone + " User Address: " + userList.Value.userAddress +
                    "\nUser Email: " + userList.Value.userEmail);
            }
        }
        public void GamesAvailable(Games games)
        {
            Console.WriteLine("Games Available:");
            foreach (var gameNotRented in games.GamesDictObj)
            {
                if (gameNotRented.Value.rentedStatus == "Not Rented")
                {
                    Console.WriteLine("Game ID: " + gameNotRented.Key + "\nGame Name: " + gameNotRented.Value.gamesName);
                }
            }
        }
        public void GamesRented(Games games)
        {
            Console.WriteLine("Games Rented:");
            foreach (var rentedgame in games.GamesDictObj)
            {
                if (rentedgame.Value.rentedStatus == "Rented")
                {
                    Console.WriteLine("Game ID: " + rentedgame.Key + "\nGame Name: " + rentedgame.Value.gamesName + "\nRented By: " + rentedgame.Value.rentedBy);
                }
            }
        }
        public void OverduedGames(DateTime dateTime, Games games)
        {
            Console.WriteLine("Overdued Games:");
            foreach (var gamesDue in games.GamesDictObj)
            {
                DateTime convertedReturnDate = DateTime.Parse(gamesDue.Value.returnByDate + " 12:00:00 AM");
                double daysLate = ((dateTime - convertedReturnDate).TotalDays);
                if (gamesDue.Value.returnByDate != "" && daysLate > 0)
                {
                    Console.WriteLine("Game ID: " + gamesDue.Key + " Game Name: " + gamesDue.Value.gamesName +
                        "\nRented By: " + gamesDue.Value.rentedBy + " Return By: " + gamesDue.Value.returnByDate);
                }
            }
        }
        public void TotalEarned(Earned earned)
        {
            double earnedProfit = earned.EarnedListObj.Sum();
            Console.WriteLine("Current amount earned in total: $" + earnedProfit);
        }
    }
}