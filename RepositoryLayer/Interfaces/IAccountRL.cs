﻿using CommonLayer.Model;
using System;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IAccountRL
    {
        Task<Tuple<bool,string>> AddUser(RegistrationModel registrationModel);
    }
}
