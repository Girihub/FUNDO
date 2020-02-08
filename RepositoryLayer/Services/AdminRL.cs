//----------------------------------------------------
// <copyright file="AdminRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using CommonLayer.Response;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;

    /// <summary>
    /// class AdminRL implements interface IAdminRL
    /// </summary>
    public class AdminRL : IAdminRL
    {
        /// <summary>
        /// private field appDBContext
        /// </summary>
        private readonly AuthenticationContext appDbContext;

        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRL"/> class.
        /// </summary>
        /// <param name="appDbContext">appDBContext as a parameter</param>
        public AdminRL(AuthenticationContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Method to register admin
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<RegistrationModel> AddAdmin(RegistrationRequest registrationRequest)
        {
            try
            {
                RegistrationModel emodel = new RegistrationModel();
                string password = this.Encrypt(registrationRequest.Password);
                if (registrationRequest.ServiceType.ToLower() != "Advance".ToLower())
                {
                    registrationRequest.ServiceType = "Basic";
                }
                else
                {
                    registrationRequest.ServiceType = "Advance";
                }

                var model = new RegistrationModel()
                {
                    FirstName = registrationRequest.FirstName,
                    LastName = registrationRequest.LastName,
                    MobileNumber = registrationRequest.MobileNumber,
                    Email = registrationRequest.Email,
                    Password = password,
                    ProfilePicture = registrationRequest.ProfilePicture,
                    ServiceType = registrationRequest.ServiceType,
                    UserType = "Admin"
                };

                var row = this.appDbContext.Registration.Where(c => c.Email == registrationRequest.Email).FirstOrDefault();
                if (row == null)
                {
                    this.appDbContext.Registration.Add(model);
                    await this.appDbContext.SaveChangesAsync();
                    return model;
                }

                return emodel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to encrypt the given string input
        /// </summary>
        /// <param name="input">input as a parameter</param>
        /// <returns>returns encrypted data</returns>
        public string Encrypt(string input)
        {
            byte[] encData_byte = new byte[input.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(input);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        /// <summary>
        /// Method to decrypt encrypted data
        /// </summary>
        /// <param name="encodedData">encodedData as a parameter</param>
        /// <returns>returns decrypted data</returns>
        public string Decrypt(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new string(decoded_char);
            return result;
        }

        /// <summary>
        /// Method for Login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<RegistrationModel> LoginAdmin(LoginModel loginModel)
        {
            try
            {
                RegistrationModel model = new RegistrationModel();

                var admin = this.appDbContext.Registration.Where(c => c.Email.Equals(loginModel.Email) && c.UserType.Equals("Admin")).FirstOrDefault();

                if (admin != null)
                {
                    if (admin.Password == this.Encrypt(loginModel.Password))
                    {
                        return admin;
                    }

                    return model;
                }

                var result = await this.appDbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display User's Statistics
        /// </summary>
        /// <param name="userId">id of user as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<IDictionary<string, int>> UserStatistics(int userId)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            var user = this.appDbContext.Registration.Where(c => c.Id == userId && c.UserType.Equals("Admin")).FirstOrDefault();
            if (user != null)
            {
                var queryAllUsers = from table in this.appDbContext.Registration
                                    select table;
                int advance = 0, basic = 0;
                foreach (var row in queryAllUsers)
                {
                    if (row.ServiceType.Equals("Advance"))
                    {
                        advance++;
                    }
                    else
                    {
                        basic++;
                    }
                }

                dict.Add("Advance", advance);
                dict.Add("Basic", basic);
                return dict;
            }

            return dict;
        }

        /// <summary>
        /// Method to display user's list
        /// </summary>
        /// <param name="userId">id of admin user</param>
        /// <returns>returns result</returns>
        public List<ResponseToUser> UserList(int userId)
        {
            List<ResponseToUser> users = new List<ResponseToUser>();

            var admin = this.appDbContext.Registration.Where(c => c.Id == userId && c.UserType.Equals("Admin")).FirstOrDefault();

            if (admin != null)
            {
                foreach (var row in this.appDbContext.Registration)
                {
                    var user = new ResponseToUser()
                    {
                        Id=row.Id,
                        FirstName=row.FirstName,
                        LastName=row.LastName,
                        MobileNumber=row.MobileNumber,
                        Email=row.Email,
                        ProfilePicture=row.ProfilePicture,
                        ServiceType=row.ServiceType,
                        UserType=row.UserType
                    };
                    users.Add(user);
                }
            }

            return users;
        }
       
    }
}
