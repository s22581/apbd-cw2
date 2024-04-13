using System;

namespace LegacyApp.Abstractions
{
    public interface IUserFactory
    {
        User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client);
    }
}
