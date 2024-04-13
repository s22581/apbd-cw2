using System;
using LegacyApp.Abstractions;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly IUserFactory _userFactory;
        private readonly IUserSaver _userSaver;

        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _userFactory = new UserFactory();
            _userSaver = new UserSaver();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!UserValidator.isUserValid(firstName, lastName, email, dateOfBirth))
                return false;

            var client = _clientRepository.GetById(clientId);
            if (client == null)
                return false;

            var user = _userFactory.CreateUser(firstName, lastName, email, dateOfBirth, client);
            if (user == null)
                return false;

            ProcessUserCredit(user);

            return _userSaver.SaveUser(user);
        }



        private void ProcessUserCredit(User user)
        {
            using (var userCreditService = _userCreditService)
            {
                if (user.Client.Type == "VeryImportantClient")
                {
                    user.HasCreditLimit = false;
                }
                else
                {
                    user.HasCreditLimit = true;
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    user.CreditLimit = user.Client.Type == "ImportantClient" ? creditLimit * 2 : creditLimit;
                }
            }
        }

       
    }
}
