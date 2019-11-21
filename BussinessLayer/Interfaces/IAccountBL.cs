using CommonLayer.Model;

namespace BussinessLayer.Interfaces
{
    public interface IAccountBL
    {
        bool AddUser(RegistrationModel registrationModel);
    }
}
