using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VideoGameRentalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreManager storeManager = new StoreManager();
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
                            storeManager.PerformOperationsStoreManager(dt);
                        }
                        else if (ValidateCredentialsStaff(inputID, password) == true)
                        {
                            storeManager.PerformOperationsStoreStaff();
                        }
                        else if (ValidateCredentialsUser(inputID, password) == true)
                        {
                            storeManager.PerformOperationsUser(inputID, dt);
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
        public static bool ValidateCredentialsStaff(string id, string password)
        {
            StoreManager storeManager = new StoreManager();
            return storeManager.StaffDictObj.Any(entry => entry.Key == id && entry.Value.staffPassword == password);
        }
        public static bool ValidateCredentialsUser(string id, string password)
        {
            StoreManager storeManager = new StoreManager();
            return storeManager.UserDictObj.Any(entry => entry.Key == id && entry.Value.userPassword == password);
        }
    }
}
