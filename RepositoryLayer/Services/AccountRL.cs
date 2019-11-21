using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace RepositoryLayer.Services
{
    public class AccountRL : IAccountRL
    {
        private readonly AuthenticationContext _appDbContext;

        public AccountRL(AuthenticationContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Tuple<bool, string>> AddUser(RegistrationModel registrationModel)
        {            
            try
            {
                var Model = new RegistrationModel()
                {
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    MobileNumber = registrationModel.MobileNumber,
                    Email = registrationModel.Email,
                    Password = registrationModel.Password
                };

                var queryAllCustomers = from cust in _appDbContext.Registration
                                        select cust;
                foreach(var email in queryAllCustomers)
                {
                    if(email.Email.Equals(Model.Email))
                    {
                        return Tuple.Create(false, "Email already exist....");
                    }
                }
                _appDbContext.Add(Model);
                var result = await _appDbContext.SaveChangesAsync();
                
                if (result > 0)
                {
                    return Tuple.Create(true, "Registered Successfully....");
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
            return Tuple.Create(false, "Error Occures");
        }
    }
}
