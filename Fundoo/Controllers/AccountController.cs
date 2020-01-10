//----------------------------------------------------
// <copyright file="HomeController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using CommonLayer.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.MSMQ;

    /// <summary>
    /// HomeController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// private field of business interface
        /// </summary>
        private readonly IAccountBL businessRegistration;

        /// <summary>
        /// configuration field
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="businessRegistration">businessRegistration as a parameter</param>
        /// <param name="configuration">configuration as a parameter</param>
        public AccountController(IAccountBL businessRegistration, IConfiguration configuration)
        {
            this.businessRegistration = businessRegistration;
            this.configuration = configuration;
        }        

        /// <summary>
        /// API for registration of user
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> AddUser( RegistrationRequest registrationRequest)
        {
            try
            {
                var result = await this.businessRegistration.AddUser(registrationRequest);

                if (result.Email != null)
                {
                    ResponseToUser data = new ResponseToUser()
                    {
                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        MobileNumber = result.MobileNumber,
                        Email = result.Email,
                        ProfilePicture = result.ProfilePicture,
                        ServiceType = result.ServiceType,
                        UserType = result.UserType
                    };

                    bool status = true;
                    var message = "Registered successfully...";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Email is already registered...";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        

        /// <summary>
        /// API for Login of user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("UserLogin")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> LoginUser( LoginModel loginModel)
        {
            try
            {
                var result = await this.businessRegistration.LoginUser(loginModel);
                if (result.Email != null)
                {
                    ResponseToUser data = new ResponseToUser()
                    {
                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        MobileNumber = result.MobileNumber,
                        Email = result.Email,
                        ProfilePicture = result.ProfilePicture,
                        ServiceType = result.ServiceType,
                        UserType = result.UserType                        
                    };

                    bool status = true;
                    var message = "Logged in successfully";
                    var token = this.GetToken(result.Id.ToString(), result.Email);
                    return this.Ok(new { status, message, data, token });
                }
                else
                {
                    bool status = false;
                    var message = "Invalid credentials";
                    return this.BadRequest(new { status, message });
                }
            }      
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to recover password of user
        /// </summary>
        /// <param name="forgotPassword">forgotPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            var result = this.businessRegistration.ForgotPassword(forgotPassword);
            if (!string.IsNullOrEmpty(result.Email))
            {
                result.Token = this.GetToken(result.Id.ToString(), result.Email);
                var token = result.Token;
                SendMessage.ForgotPasswordMessage(result.Email, token);
                bool status = true;
                var message = "token has been sent to your mail.";
                SendMail.SendEmail(result.Email,token);
                return this.Ok(new { status, message, result.Token });
            }
            else
            {
                bool status = false;
                var message = "Enter valid email.";
                return this.BadRequest(new { status, message });
            }            
        }

        /// <summary>
        /// API to change password of user
        /// </summary>
        /// <param name="changePassword">changePassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordModel changePassword)
        {
            ////getting the Id of note from token
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            var result = await this.businessRegistration.ChangePassword(changePassword, id);
            if (result)
            {
                bool status = true;
                var message = "Password changed";
                return this.Ok(new { status, message });
            }
            else
            {
                bool status = false;
                var message = "Invalid credentials";
                return this.BadRequest(new { status, message });
            }
        }

        /// <summary>
        /// API to get password of user
        /// </summary>
        /// <param name="getPassword">getPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("GetPassword")]
        public IActionResult GetPassword([FromForm] GetPasswordModel getPassword)
        {
            try
            {
                var result = this.businessRegistration.GetPassword(getPassword);
                return this.Ok(new { result });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to reset forgotten password of user
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword( ResetPasswordModel resetPassword)
        {
            try
            {
                var result = await this.businessRegistration.ResetPassword(resetPassword);
                if (result)
                {
                    bool status = true;
                    var message = "Password reset successfully...";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = false;
                    var message = "Check token. New password can't be same as old password";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to upload profile picture
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <returns>returns result in JSON format</returns>
        [Authorize]
        [HttpPost("UploadProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile formFile)
        {
            ////getting the Id of note from token
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);

            ////alternate code to get id from token
            ////int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);

            var data = await this.businessRegistration.UploadProfilePicture(id, formFile);
            try
            {
                if (data != null)
                {
                    var status = true;
                    var message = "image uploaded successfully";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var status = false;
                    var message = "Enter valid id";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// API to generate token
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="email">email as a parameter</param>
        /// <returns>returns token</returns>
        [HttpGet]
        public string GetToken(string id, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                        //// Claims the identity
                                        new Claim("Id", id.ToString()),
                                        new Claim("Email", email.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(720),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var secureToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(secureToken);
            return token;
        }
    }
}   