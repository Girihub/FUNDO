using CommonLayer.Model;
using System;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IAccountBL
    {
        Task<Tuple<bool,string>> AddUser(RegistrationModel registrationModel);

        Task<Tuple<bool, string>> LoginUser(LoginModel loginModel);
    }
}
