﻿using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class AccountBL : IAccountBL
    {
        private readonly IAccountRL _repository;

        public AccountBL(IAccountRL repository)
        {
            this._repository = repository;
        }

        public async Task<Tuple<bool, string>> AddUser(RegistrationModel registrationModel)
        {
            return await this._repository.AddUser(registrationModel);
        }

        public async Task<Tuple<bool, string>> LoginUser(LoginModel loginModel)
        {
            return await this._repository.LoginUser(loginModel);
        }
    }
}
