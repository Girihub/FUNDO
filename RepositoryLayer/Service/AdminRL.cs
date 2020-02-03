using CommonLayer;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly IConfiguration configuration;

        private readonly AuthenticationContext authenticationContext;

        public AdminRL(IConfiguration configuration, AuthenticationContext authenticationContex)
        {
            this.configuration = configuration;
            this.authenticationContext = authenticationContex;
        }

        public async Task<AdminResponse> AddAdmin(AdminRequest adminRequest)
        {
            try
            {
                AdminResponse adminResponse = new AdminResponse();
                var row = this.authenticationContext.Admin.Where(c => c.MobileNumber == adminRequest.MobileNumber).FirstOrDefault();

                if (row == null)
                {
                    var admin = new Admin()
                    {
                        FirstName = adminRequest.FirstName,
                        LastName = adminRequest.LastName,
                        MobileNumber = adminRequest.MobileNumber,
                        UserName = adminRequest.UserName,
                        Password = adminRequest.Password,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    this.authenticationContext.Admin.Add(admin);
                    await this.authenticationContext.SaveChangesAsync();
                    var data = new AdminResponse()
                    {
                        FirstName = admin.FirstName,
                        LastName = admin.LastName,
                        MobileNumber = admin.MobileNumber,
                        UserName = admin.UserName
                    };
                    return data;
                }

                return adminResponse;
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
                var admin = this.authenticationContext.Admin.Where(c => c.UserName == loginRequest.UserName && c.Password == loginRequest.Password).FirstOrDefault();

                LoginResponse response = new LoginResponse();

                if (admin != null)
                {
                    response.Id = admin.Id;
                    response.FirstName = admin.FirstName;
                    response.LastName = admin.LastName;
                    response.MobileNumber = admin.MobileNumber;
                    response.UserName = admin.UserName;
                    return response;
                }

                return response;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
