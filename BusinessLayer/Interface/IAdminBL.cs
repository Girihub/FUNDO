using CommonLayer;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        Task<AdminResponse> AddAdmin(AdminRequest admin);

        LoginResponse AdminLogin(LoginRequest loginRequest);
    }
}
