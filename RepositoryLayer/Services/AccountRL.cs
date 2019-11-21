using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class AccountRL : IAccountRL
    {
        private readonly AuthenticationContext _appDbContext;

        public AccountRL(AuthenticationContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddUser(RegistrationModel registrationModel)
        {
            var Model = new RegistrationModel()
            {
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                MobileNumber=registrationModel.MobileNumber,
                Email=registrationModel.Email,
                Password=registrationModel.Password
            };
            try
            {
                  _appDbContext.Add(Model);
                var result = await _appDbContext.SaveChangesAsync();
                
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
            return false;
        }
    }
}
