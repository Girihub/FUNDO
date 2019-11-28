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
            try
            {
                if (registrationModel != null)
                {
                    return await this.repository.AddUser(registrationModel);
                }
                else
                {
                    throw new Exception("RegistrationModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// Method to implement LoginUser
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>boolean value and string</returns>
        public async Task<Tuple<bool, string>> LoginUser(LoginModel loginModel)
        {
            try
            {
                if (loginModel != null)
                {
                    return await this.repository.LoginUser(loginModel);
                }
                else
                {
                    throw new Exception("LoginModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// Method to recover the password
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public string ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                if(forgotPassword != null)
                {
                    return this.repository.ForgotPassword(forgotPassword);
                }
                else
                {
                    throw new Exception("ForgotPasswordModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        /// <summary>
        /// Method to reset the password
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public string ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                if(resetPassword != null)
                {
                    return this.repository.ResetPassword(resetPassword);
                }
                else
                {
                    throw new Exception("ResetPasswordModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
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
                if(getPassword != null)
                {
                    return this.repository.GetPassword(getPassword);
                }
                else
                {
                    throw new Exception("GetPasswordModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        /// <summary>
        /// Method to reset the forgotten password
        /// </summary>
        /// <param name="resetForgetPassword">resetForgetPassword as a parameter</param>
        /// <returns>returns string output</returns>
        public async Task<string> ResetForgetPassword(ResetForgetPasswordModel resetForgetPassword)
        {
            try
            {
                if(resetForgetPassword != null)
                {
                    return await this.repository.ResetForgetPassword(resetForgetPassword);
                }
                else
                {
                    throw new Exception("ResetForgetPasswordModel can not be null");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }
    }
}
