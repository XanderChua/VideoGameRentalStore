using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameRental.Common.DTO;

namespace VideoGameRentalStore.Interfaces
{
    interface IVideoGameRentalViewModel
    {
        void Initialize();

        //Authetication
        ICollection<StoreStaffDTO> ValidateStaff(string inputID, string password);
        ICollection<UserDTO> ValidateUser(string inputID, string password);

        //Store Manager       
        StoreStaffDTO AddStaff(string inputStaffID, string inputStaffPassword, string inputStaffName, string inputStaffPhone, string inputStaffAddress, string inputStaffEmail);
        GamesDTO AddGames(string inputGamesID, string inputGamesName, string rentPrice);
        ICollection<StoreStaffDTO> ListStaff();
        ICollection<UserDTO> ListUser();
        ICollection<GamesDTO> GamesAvailable();
        ICollection<GamesDTO> RentedGames();
        GamesDTO OverduedGames(DateTime dateTime);
        double TotalEarned();

        //Store Staff
        UserDTO AddUser(string inputUserID, string inputUserPassword, string inputUserName, string inputUserPhone, string inputUserAddress, string inputUserEmail);
        GamesDTO SearchUser(string searchUserByGames);
        GamesDTO SearchGame(string searchGamesByUser);

        //User
        GamesDTO Rent(string id, DateTime dateTime, string selectGameRent);
        GamesDTO Return(string id, DateTime dateTime, string selectGameRent);
        GamesDTO ListRentedGames(string id);
    }
}
