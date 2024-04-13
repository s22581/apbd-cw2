using System;

namespace LegacyApp.Abstractions
{
    public interface IUserCreditService : IDisposable
    {
        int GetCreditLimit(string lastName);
    }
}
