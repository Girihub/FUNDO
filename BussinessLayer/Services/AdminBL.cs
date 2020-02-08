//----------------------------------------------------
// <copyright file="AccountBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using CommonLayer.Constants;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        /// <summary>
        /// declare private field repository
        /// </summary>
        private readonly IAdminRL repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBL"/> class.
        /// </summary>
        /// <param name="repository">repository as a parameter</param>
        public AdminBL(IAdminRL repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method to implement Add Admin
        /// </summary>
        /// <param name="registrationModel">registration Model as a parameter</param>
        /// <returns>Returns result</returns>
        public async Task<RegistrationModel> AddAdmin(RegistrationRequest registrationRequest)
        {
            try
            {
                return await this.repository.AddAdmin(registrationRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to implement Login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<RegistrationModel> LoginAdmin(LoginModel loginModel)
        {
            try
            {
                return await this.repository.LoginAdmin(loginModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for User Statistics
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>returns result</returns>
        public async Task<IDictionary<string, int>> UserStatistics(int userId)
        {
            try
            {
                return await this.repository.UserStatistics(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display user's list
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>returns result</returns>
        public List<ResponseToUser> UserList(int userId)
        {
            try
            {
                return this.repository.UserList(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
    }
}
