//----------------------------------------------------
// <copyright file="IAccountBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Interfaces
{    
    using System;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Interface for business layer
    /// </summary>
    public interface IAccountBL
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

        /// <summary>
        /// Method declaration to recover the password
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns string output</returns>
        string ForgotPassword(ForgotPasswordModel forgotPassword);

        /// <summary>
        /// Method declaration to reset the password
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns string output</returns>
        string ResetPassword(ResetPasswordModel resetPassword);

        /// <summary>
        /// Method declaration to get the password
        /// </summary>
        /// <param name="getPassword">getPassword as a parameter</param>
        /// <returns>returns string output</returns>
        string GetPassword(GetPasswordModel getPassword);

        /// <summary>
        /// Method declaration to reset the forgotten password
        /// </summary>
        /// <param name="resetForgetPassword">resetForgetPassword as a parameter</param>
        /// <returns>returns string output</returns>
        Task<string> ResetForgetPassword(ResetForgetPasswordModel resetForgetPassword);

        /// <summary>
        /// Method declaration to Upload Profile Picture
        /// </summary>
        /// <param name="id">id of user</param>
        /// <param name="formFile">formFile to upload profile picture</param>
        /// <returns>returns result</returns>
        Task<string> UploadProfilePicture(int id, IFormFile formFile);

        /// <summary>
        /// Method declaration for registration of admin
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        Task<bool> AddAdmin(RegistrationRequest registrationRequest);

        /// <summary>
        /// Method declaration for login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        Task<string> LoginAdmin(LoginModel loginModel);
    }
}
