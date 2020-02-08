//----------------------------------------------------
// <copyright file="AccountBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{    
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Constants;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using CommonLayer.Response;
    using Microsoft.AspNetCore.Http;
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
        /// <param name="registrationRequest">registrationRequest Model</param>
        /// <returns>boolean value and string</returns>
        public async Task<RegistrationModel> AddUser(RegistrationRequest registrationRequest)
        {
            try
            {
                return await this.repository.AddUser(registrationRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        

        /// <summary>
        /// Method to implement LoginUser
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>boolean value and string</returns>
        public async Task<RegistrationModel> LoginUser(LoginModel loginModel)
        {
            try
            {
                return await this.repository.LoginUser(loginModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to recover the password
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public ForgotPasswordResponse ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                return this.repository.ForgotPassword(forgotPassword);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to reset the password
        /// </summary>
        /// <param name="changePassword">changePassword as a parameter</param>
        /// <returns>returns string output</returns>
        public async Task<bool> ChangePassword(ChangePasswordModel changePassword, int id)
        {
            try
            {
                return await this.repository.ChangePassword(changePassword, id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to get the password
        /// </summary>
        /// <param name="getPassword">getPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public string GetPassword(GetPasswordModel getPassword)
        {
            try
            {
                return this.repository.GetPassword(getPassword);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to reset the forgotten password
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public async Task<bool> ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                return await this.repository.ResetPassword(resetPassword);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to Upload Profile Picture
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="formFile">formFile interface to select desired image</param>
        /// <returns>returns result</returns>
        public async Task<string> UploadProfilePicture(int id, IFormFile formFile)
        {
            try
            {
                return await this.repository.UploadProfilePicture(id, formFile);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ResponseToUser> AllUsers(int userId)
        {
            try
            {
                return this.repository.AllUsers(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
