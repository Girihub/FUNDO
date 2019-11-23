

namespace RepositoryLayer.Services
{
    using CommonLayer.Model;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using Experimental.System.Messaging;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.MSMQ;
    using System.Text;

    public class AccountRL : IAccountRL
    {
        private readonly AuthenticationContext appDbContext;

        public AccountRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
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
                               
                
                var queryAllUsers = from table in this.appDbContext.Registration
                                        select table;
                foreach(var email in queryAllUsers)
                {
                    if(email.Email.Equals(Model.Email))
                    {
                        return Tuple.Create(false, "Email already exist....");
                    }
                }
                this.appDbContext.Add(Model);
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
                var queryAllUsers = from table in this.appDbContext.Registration
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

                var result = await this.appDbContext.SaveChangesAsync();
               return Tuple.Create(false, "Email is wrong");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

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

                    return "token has been sent on "+ forgotPassword.Email;
                }
                return "Invalid email";
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
