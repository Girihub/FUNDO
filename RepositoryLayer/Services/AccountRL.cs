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
    using System.Security.Claims;
    using System.Threading.Tasks;        
    using CommonLayer.Model;        
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;
    using RepositoryLayer.MSMQ;

    /// <summary>
    /// class AccountRL implements interface IAccountRL
    /// </summary>
    public class AccountRL : IAccountRL
    {
        /// <summary>
        /// private field appDBContext
        /// </summary>
        private readonly AuthenticationContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRL"/> class.
        /// </summary>
        /// <param name="appDbContext">appDBContext as a parameter</param>
        public AccountRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Method to register user
        /// </summary>
        /// <param name="registrationModel">registrationModel as a parameter</param>
        /// <returns>returns string value and boolean value</returns>
        public async Task<Tuple<bool, string>> AddUser(RegistrationModel registrationModel)
        {            
            try
            {
                string password = this.Encrypt(registrationModel.Password);
                var model = new RegistrationModel()
                {
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    MobileNumber = registrationModel.MobileNumber,
                    Email = registrationModel.Email,
                    Password = password
                };                 
                var queryAllUsers = from table in this.appDbContext.Registration
                                        select table;
                foreach (var email in queryAllUsers)
                {
                    if (email.Email.Equals(model.Email))
                    {
                        return Tuple.Create(false, "Email already exist....");
                    }
                }

                this.appDbContext.Add(model);
                var result = await this.appDbContext.SaveChangesAsync();
                
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
        public async Task<Tuple<bool, string>> LoginUser(LoginModel loginModel)
        {
            try
            {
                var queryAllUsers = from table in this.appDbContext.Registration
                                        select table;

                foreach (var email in queryAllUsers)
                {
                    if (email.Email.Equals(loginModel.Email))
                    {
                        foreach (var password in queryAllUsers)
                        {
                            if (this.Decrypt(password.Password).Equals(loginModel.Password))
                            {
                                var tokenHandler = new JwtSecurityTokenHandler();
                                var tokenDescriptor = new SecurityTokenDescriptor
                                {
                                    Subject = new ClaimsIdentity(new Claim[]
                                    {
                                    //// Claims the identity
                                    new Claim("Email", loginModel.Email.ToString())
                                    }),
                                    Expires = DateTime.UtcNow.AddDays(1)
                                };
                                var secureToken = tokenHandler.CreateToken(tokenDescriptor);
                                var token = tokenHandler.WriteToken(secureToken);
                                return Tuple.Create(true, "Logged in Successfully. Your token is " + token);
                            }
                        }

                        return Tuple.Create(false, "Password does not match with email");
                    }
                }

                var result = await this.appDbContext.SaveChangesAsync();
               return Tuple.Create(false, "Email is wrong");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to recover password
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns string value</returns>
        public string ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                //// lambda expression to get the particular user from db
                var user = this.appDbContext.Registration.Where(g => g.Email == forgotPassword.Email).FirstOrDefault();

                if (user.Email.Equals(forgotPassword.Email))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            //// Claims the identity
                            new Claim("Email", user.Email.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1)
                    };
                    var secureToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(secureToken);

                    SendMessage.ForgotPasswordMessage(forgotPassword.Email, token);

                    return "token has been sent on " + forgotPassword.Email;
                }

                return "Invalid email";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to reset password
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns string value</returns>
        public string ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                var allUsers = from table in this.appDbContext.Registration
                                    select table;
                foreach (var user in allUsers.ToList())
                {
                    if (user.Email.Equals(resetPassword.Email))
                    {
                        if (this.Decrypt(user.Password).Equals(resetPassword.OldPassword))
                        {
                            if (resetPassword.NewPassword.Equals(resetPassword.ConfirmPassword))
                            {
                                user.Password = this.Encrypt(resetPassword.ConfirmPassword);
                                this.appDbContext.SaveChangesAsync();
                                return "Password reset successfully";
                            }

                            return "NewPassword and ConfirmPassword does not match";
                        }

                        return "Incorrest old password";
                    }
                }

                return "Invalid email";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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

        public async Task<string> ResetForgetPassword(ResetForgetPasswordModel resetForgetPassword)
        {
            try
            {
                var stream = resetForgetPassword.Token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                var email = tokenS.Claims.First(claim => claim.Type == "Email").Value;

                var user = this.appDbContext.Registration.Where(g => g.Email == email).FirstOrDefault();                
                if (user != null)
                {
                    if(this.Encrypt(resetForgetPassword.NewPassword) == this.Encrypt(resetForgetPassword.ConfirmPassword))
                    {
                        if (user.Password != this.Encrypt(resetForgetPassword.NewPassword))
                        {
                            user.Password = this.Encrypt(resetForgetPassword.NewPassword);
                            var result = await this.appDbContext.SaveChangesAsync();
                            return "Password reset successfully";
                        }
                        return "NewPassword cant be same as Old Password";
                    }
                    return "NewPassword and ConfirmPassword should be same";
                }                
                return "Invalid token for email";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
