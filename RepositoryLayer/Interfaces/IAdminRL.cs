﻿//----------------------------------------------------
// <copyright file="IAccountRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        Task<RegistrationModel> AddAdmin(RegistrationRequest registrationRequest);

        Task<RegistrationModel> LoginAdmin(LoginModel loginModel);

        Task<IDictionary<string, int>> UserStatistics(int userId);

        List<ResponseToUser> UserList(int userId);
        
    }
}