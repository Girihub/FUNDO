using CommonLayer.Model;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IAccountRL
    {
        Task<bool> AddUser(RegistrationModel registrationModel);
    }
}
