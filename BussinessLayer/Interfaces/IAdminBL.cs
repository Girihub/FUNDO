//----------------------------------------------------
// <copyright file="IAccountBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.Request;

namespace BussinessLayer.Interfaces
{
    public interface IAdminBL
    {
        /// <summary>
        /// Method declaration for registration of admin
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        Task<RegistrationModel> AddAdmin(RegistrationRequest registrationRequest);

        /// <summary>
        /// Method declaration for login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        Task<RegistrationModel> LoginAdmin(LoginModel loginModel);

        /// <summary>
        /// Method declaration for User Statistics
        /// </summary>
        /// <param name="userId">Id of user as a parameter</param>
        /// <returns>returns result</returns>
        Task<IDictionary<string, int>> UserStatistics(int userId);

        /// <summary>
        /// Method declaration for User's List
        /// </summary>
        /// <param name="userId">Id of user as a parameter</param>
        /// <returns>returns result</returns>
        Task<IList<RegistrationModel>> UserList(int userId);
    }
}
