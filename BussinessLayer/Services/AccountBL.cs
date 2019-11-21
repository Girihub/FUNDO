using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class AccountBL : IAccountBL
    {
        private IAccountRL repository;

        public AccountBL(IAccountRL repository)
        {
            this.repository = repository;
        }

        public bool AddUser(RegistrationModel registrationModel)
        {
            return this.repository.AddUser(registrationModel);
        }
    }
}
