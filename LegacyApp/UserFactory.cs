using System;
using LegacyApp.Abstractions;

namespace LegacyApp
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
             => new User()
             {
                 FirstName = firstName,
                 LastName = lastName,
                 EmailAddress = email,
                 DateOfBirth = dateOfBirth,
                 Client = client
             };
    }
}
