//----------------------------------------------------
// <copyright file="IAccountRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// IAccountRL interface
    /// </summary>
    public interface IAccountRL
    {
        /// <summary>
        /// Method declaration for registration of user
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns boolean value and string</returns>
        Task<Tuple<bool, string>> AddUser(RegistrationRequest registrationRequest);

        /// <summary>
        /// Method declaration for login of user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns boolean value and string</returns>
        Task<Tuple<bool, string>> LoginUser(LoginModel loginModel);

        string ForgotPassword(ForgotPasswordModel forgotPassword);

        string ResetPassword(ResetPasswordModel resetPassword);

        string GetPassword(GetPasswordModel getPassword);

        Task<string> ResetForgetPassword(ResetForgetPasswordModel resetForgetPassword);

        Task<string> UploadProfilePicture(int id, IFormFile formFile);        
    }
}
