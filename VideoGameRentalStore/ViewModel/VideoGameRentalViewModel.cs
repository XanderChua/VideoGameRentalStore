﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VideoGameRental.Common.DTO;
using VideoGameRentalStore.Interfaces;

namespace VideoGameRentalStore.ViewModel
{
    class VideoGameRentalViewModel : IVideoGameRentalViewModel
    {
        private HttpClient _httpClient;
        private string baselink = "https://localhost:44353/api";
        public VideoGameRentalViewModel() { }

        public void Initialize()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baselink);
        }
        //Authentication
        public bool ValidateStaff(string inputID, string password)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/VerifyStaff/Login");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Staff login success!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return bool.Parse(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }

        public bool ValidateUser(string inputID, string password)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/VerifyUser/Login");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("User login success!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return bool.Parse(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }

        //Store Manager
        public StoreStaffDTO AddStaff(string inputStaffID, string inputStaffPassword, string inputStaffName, string inputStaffPhone, string inputStaffAddress, string inputStaffEmail)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/AddStaff");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Staff added!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<StoreStaffDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public GamesDTO AddGames(string inputGamesID, string inputGamesName, string rentPrice)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/AddGames");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Games added!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public ICollection<StoreStaffDTO> ListStaff()
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/ListStaff");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<ICollection<StoreStaffDTO>>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public ICollection<UserDTO> ListUser()
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/ListUser");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<ICollection<UserDTO>>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public ICollection<GamesDTO> GamesAvailable()
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/AvailableGames");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<ICollection<GamesDTO>>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public ICollection<GamesDTO> RentedGames()
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/GamesRented");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<ICollection<GamesDTO>>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public GamesDTO OverduedGames(DateTime dateTime)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/OverduedGames");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public double TotalEarned()
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreManager/TotalEarned");
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<double>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }

        //Store Staff
        public UserDTO AddUser(string inputUserID, string inputUserPassword, string inputUserName, string inputUserPhone, string inputUserAddress, string inputUserEmail)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreStaffManager/AddUser");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("User added!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<UserDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        //GamesAvailable()
        public GamesDTO SearchUser(string searchUserByGames)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreStaffManager/SearchUser");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public GamesDTO SearchGame(string searchGamesByUser)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/StoreStaffManager/SearchGames");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }

        //User
        public GamesDTO Rent(string id, DateTime dateTime, string selectGameRent)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/UserManager/Rent");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Rent success!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public GamesDTO Return(string id, DateTime dateTime, string selectGameRent)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/UserManager/Return");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Return success!");
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
        public GamesDTO ListRentedGames(string id)
        {
            Task<string> responseBody;
            var response = _httpClient.GetAsync($"{baselink}/UserManager/RentedGames");
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                responseBody.Wait();
                return JsonConvert.DeserializeObject<GamesDTO>(responseBody.Result);
            }
            else
            {
                responseBody = response.Result.Content.ReadAsStringAsync();
                throw new Exception(responseBody.Result);
            }
        }
    }
}
