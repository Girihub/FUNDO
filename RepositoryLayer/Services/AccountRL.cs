using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;

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
                string password = this.Encrypt(registrationModel.Password);
                var Model = new RegistrationModel()
                {
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    MobileNumber = registrationModel.MobileNumber,
                    Email = registrationModel.Email,
                    Password = password
                };
                               
                
                var queryAllUsers = from table in _appDbContext.Registration
                                        select table;
                foreach(var email in queryAllUsers)
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

        public string Encrypt(string input)
        {
            byte[] encData_byte = new byte[input.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(input);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public string Decrypt(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public async Task<Tuple<bool, string>> LoginUser(LoginModel loginModel)
        {
            try
            {
                var queryAllUsers = from table in _appDbContext.Registration
                                        select table;

                foreach (var email in queryAllUsers)
                {
                    if (email.Email.Equals(loginModel.Email))
                    {
                        foreach(var password in queryAllUsers)
                        {
                            if (this.Decrypt(password.Password).Equals(loginModel.Password))
                            {
                                return Tuple.Create(true, "Logged in Successfully");
                            }
                        }
                        return Tuple.Create(false, "Password does not match with email");
                    }
                }

                var result = await _appDbContext.SaveChangesAsync();
               return Tuple.Create(false, "Email does not exist");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
