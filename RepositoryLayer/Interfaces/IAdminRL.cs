//----------------------------------------------------
// <copyright file="IAccountRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.Request;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        Task<bool> AddAdmin(RegistrationRequest registrationRequest);

        Task<string> LoginAdmin(LoginModel loginModel);

        Task<IDictionary<string, int>> UserStatistics(int userId);

        Task<IList<RegistrationModel>> UserList(int userId);
    }
}
