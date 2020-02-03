using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL repositoryAdmin;

        public AdminBL(IAdminRL repositoryAdmin)
        {
            this.repositoryAdmin = repositoryAdmin;
        }

        public async Task<AdminResponse> AddAdmin(AdminRequest admin)
        {
            try
            {
                return await this.repositoryAdmin.AddAdmin(admin);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LoginResponse AdminLogin(LoginRequest loginRequest)
        {
            try
            {
                return this.repositoryAdmin.AdminLogin(loginRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        } 
    }
}
