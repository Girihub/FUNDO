using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AccountRL : IAccountRL
    {
        private readonly AuthenticationContext appDbContext;

        public AccountRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool AddUser(RegistrationModel registrationModel)
        {
            appDbContext.Add(registrationModel);
            appDbContext.SaveChanges();
            return true;
        }
    }
}
