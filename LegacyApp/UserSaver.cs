using LegacyApp.Abstractions;
using System;

namespace LegacyApp
{
    public class UserSaver : IUserSaver
    {
        public  bool SaveUser(User user) 
        {
            try
            {
                UserDataAccess.AddUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the user: {ex.Message}");
                return false;
            }
        }
    }
}
