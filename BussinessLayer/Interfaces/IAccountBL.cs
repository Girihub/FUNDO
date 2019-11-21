using CommonLayer.Model;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IAccountBL
    {
        Task<bool> AddUser(RegistrationModel registrationModel);
    }
}
