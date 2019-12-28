//----------------------------------------------------
// <copyright file="AccountRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using CommonLayer.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;

    /// <summary>
    /// class AccountRL implements interface IAccountRL
    /// </summary>
    public class AccountRL : IAccountRL
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
        public AccountRL(AuthenticationContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }        

        /// <summary>
        /// Method to register user
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns string value and boolean value</returns>
        public async Task<RegistrationModel> AddUser(RegistrationRequest registrationRequest)
        {            
            try
            {
                RegistrationModel emodel = new RegistrationModel();
                if (registrationRequest.ServiceType.ToLower() != "Advance".ToLower())
                {
                    registrationRequest.ServiceType = "Basic";
                }
                else
                {
                    registrationRequest.ServiceType = "Advance";
                }
                string password = this.Encrypt(registrationRequest.Password);
                var model = new RegistrationModel()
                {
                    FirstName = registrationRequest.FirstName,
                    LastName = registrationRequest.LastName,
                    MobileNumber = registrationRequest.MobileNumber,
                    Email = registrationRequest.Email,
                    Password = password,
                    ProfilePicture = registrationRequest.ProfilePicture,
                    ServiceType = registrationRequest.ServiceType,
                    UserType = "User"
                };
                var user = this.appDbContext.Registration.Where(c => c.Email == registrationRequest.Email).FirstOrDefault();

                if(user == null)
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
        /// Method for Login user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns string value and boolean value</returns>
        public async Task<RegistrationModel> LoginUser(LoginModel loginModel)
        {
            try
            {
                RegistrationModel model = new RegistrationModel();

                var queryAllUsers = from table in this.appDbContext.Registration
                                        select table;

                foreach (var user in queryAllUsers)
                {
                    if (user.Email.Equals(loginModel.Email) && user.UserType.Equals("User"))
                    {
                        if (this.Decrypt(user.Password).Equals(loginModel.Password))
                        {
                            return user;
                        }
                        else
                        {
                            return model;
                        }
                        
                    }
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
        /// Method to recover password
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns string value</returns>
        public ForgotPasswordResponse ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                //// lambda expression to get the particular user from db
                var user = this.appDbContext.Registration.Where(g => g.Email == forgotPassword.Email).FirstOrDefault();
                ForgotPasswordResponse response = new ForgotPasswordResponse();
                if (user != null)
                {
                    response.Id = user.Id;
                    response.Email = user.Email; 
                    return response;
                }

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to change password
        /// </summary>
        /// <param name="changePassword">changePassword as a parameter</param>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns output</returns>
        public async Task<bool> ChangePassword(ChangePasswordModel changePassword, int id)
        {
            try
            {
                var user = this.appDbContext.Registration.Where(c => c.Id == id).FirstOrDefault();
                if(user != null)
                {
                    if(user.Password == this.Encrypt(changePassword.OldPassword))
                    {
                        user.Password = this.Encrypt(changePassword.NewPassword);
                        await this.appDbContext.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to get password of user
        /// </summary>
        /// <param name="getPassword">getPassword as a parameter</param>
        /// <returns>returns result</returns>
        public string GetPassword(GetPasswordModel getPassword)
        {
            try
            {
                //// lambda expression to get the particular user from db
                var user = this.appDbContext.Registration.Where(g => g.Email == getPassword.Email).FirstOrDefault();
                if(user != null)
                {
                    return this.Decrypt(user.Password);
                }
                return "Email does not exist";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to reset forgotten password
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<bool> ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                var stream = resetPassword.Token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                var email = tokenS.Claims.First(claim => claim.Type == "Email").Value;

                var user = this.appDbContext.Registration.Where(g => g.Email == email).FirstOrDefault();                
                if (user != null)
                {
                    if (user.Password != this.Encrypt(resetPassword.NewPassword))
                    {
                        user.Password = this.Encrypt(resetPassword.NewPassword);
                        var result = await this.appDbContext.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }  
                
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to Upload Profile Picture
        /// </summary>
        /// <param name="id">id of user as a parameter</param>
        /// <param name="formFile">formFile interface to select desired image</param>
        /// <returns>returns result</returns>
        public async Task<string> UploadProfilePicture(int id, IFormFile formFile)
        {
            try
            {
                ImageCloudinary cloudiNary = new ImageCloudinary(configuration);

                var user = this.appDbContext.Registration.Where(g => g.Id == id).FirstOrDefault();
                string url = null;
                if(user != null)
                {
                    user.ProfilePicture = cloudiNary.UploadImage(formFile);
                    await this.appDbContext.SaveChangesAsync();
                    url = user.ProfilePicture;
                    return url;
                }
                else
                {
                    return url;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }        
    }
}
