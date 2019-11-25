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
    }
}
