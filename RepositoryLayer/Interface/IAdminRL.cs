using CommonLayer;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        Task<AdminResponse> AddAdmin(AdminRequest admin);

        LoginResponse AdminLogin(LoginRequest loginRequest);
    }
}
