using System;

namespace LegacyApp
{
    public static class UserValidator
    {
        public static bool isUserValid(string firstName, string lastName, string email, DateTime dateOfBirth)
            => !string.IsNullOrEmpty(firstName) &&
                   !string.IsNullOrEmpty(lastName) &&
                   email.Contains("@") && email.Contains(".") &&
                   (DateTime.Now.Year - dateOfBirth.Year) >= 21;
    }
}
