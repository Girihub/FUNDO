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

    /// <summary>
    /// Interface for business layer
    /// </summary>
    public interface IAccountBL
    {
        /// <summary>
        /// Method declaration for registration of user
        /// </summary>
        /// <param name="registrationModel">registrationModel as a parameter</param>
        /// <returns>returns boolean value and string</returns>
        Task<Tuple<bool, string>> AddUser(RegistrationModel registrationModel);

        /// <summary>
        /// Method declaration for login of user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns boolean value and string</returns>
        Task<Tuple<bool, string>> LoginUser(LoginModel loginModel);

        string ForgotPassword(ForgotPasswordModel forgotPassword);
    }
}
