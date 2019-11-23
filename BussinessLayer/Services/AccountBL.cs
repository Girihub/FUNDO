//----------------------------------------------------
// <copyright file="AccountBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{    
    using System;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using RepositoryLayer.Interfaces;

    /// <summary>
    /// class AccountBL implements interface IAccountBL
    /// </summary>
    public class AccountBL : IAccountBL
    {
        /// <summary>
        /// declare private field repository
        /// </summary>
        private readonly IAccountRL repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBL"/> class.
        /// </summary>
        /// <param name="repository">repository as a parameter</param>
        public AccountBL(IAccountRL repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method to implement Add User
        /// </summary>
        /// <param name="registrationModel">registration Model</param>
        /// <returns>boolean value and string</returns>
        public async Task<Tuple<bool, string>> AddUser(RegistrationModel registrationModel)
        {
            return await this.repository.AddUser(registrationModel);
        }

        /// <summary>
        /// Method to implement LoginUser
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>boolean value and string</returns>
        public async Task<Tuple<bool, string>> LoginUser(LoginModel loginModel)
        {
            return await this.repository.LoginUser(loginModel);
        }

        public string ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            return this.repository.ForgotPassword(forgotPassword);
        }        
    }
}
