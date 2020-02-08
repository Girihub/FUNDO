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
    using CommonLayer.Response;
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
        Task<RegistrationModel> AddUser(RegistrationRequest registrationRequest);

        /// <summary>
        /// Method declaration for login of user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns boolean value and string</returns>
        Task<RegistrationModel> LoginUser(LoginModel loginModel);

        ForgotPasswordResponse ForgotPassword(ForgotPasswordModel forgotPassword);

        Task<bool> ChangePassword(ChangePasswordModel changePassword, int id);

        string GetPassword(GetPasswordModel getPassword);

        Task<bool> ResetPassword(ResetPasswordModel resetPassword);

        Task<string> UploadProfilePicture(int id, IFormFile formFile);

        List<ResponseToUser> AllUsers(int userId);
    }
}
