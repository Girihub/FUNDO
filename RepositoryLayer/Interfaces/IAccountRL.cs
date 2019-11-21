using CommonLayer.Model;


namespace RepositoryLayer.Interfaces
{
    public interface IAccountRL
    {
        bool AddUser(RegistrationModel registrationModel);
    }
}
