//----------------------------------------------------
// <copyright file="AdminController.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// AdminController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// private field of business interface
        /// </summary>
        private readonly IAdminBL businessRegistration;

        /// <summary>
        /// configuration field
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="businessRegistration">businessRegistration as a parameter</param>
        /// <param name="configuration">configuration as a parameter</param>
        public AdminController(IAdminBL businessRegistration, IConfiguration configuration)
        {
            this.businessRegistration = businessRegistration;
            this.configuration = configuration;
        }

        /// <summary>
        /// API for registration of admin
        /// </summary>
        /// <param name="registrationRequest">registrationRequest as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("AdminRegistration")]
        public async Task<IActionResult> AddAdmin([FromForm] RegistrationRequest registrationRequest)
        {
            var result = await this.businessRegistration.AddAdmin(registrationRequest);
            try
            {
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
        /// API for Login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result</returns>
        [HttpPost]
        [Route("AdminLogin")]
        public async Task<IActionResult> LoginAdmin([FromForm] LoginModel loginModel)
        {
            try
            {
                var result = await this.businessRegistration.LoginAdmin(loginModel);
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
        /// API for User Statistics
        /// </summary>
        /// <returns>returns result</returns>
        [HttpGet("UserStatistic")]
        [Authorize]
        public async Task<IActionResult> UserStatistics()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            var result = await this.businessRegistration.UserStatistics(userId);
            if(result.Count == 0)
            {
                bool status = false;
                var meassage = "You are not authorized to see these details";
                return this.BadRequest(new { status, meassage });
            }
            else
            {
                bool status = true;
                var meassage = "Following are user's statistics";
                return this.Ok(new { status, meassage, result });
            }
        }

        /// <summary>
        /// API for User's List
        /// </summary>
        /// <returns>returns result</returns>
        [HttpGet("UserList")]
        [Authorize]
        public async Task<IActionResult> UserList()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            var data = await this.businessRegistration.UserList(userId);

            if (data.Count != 0)
            {
                bool status = true;
                var message = "Following are the users";
                return this.Ok(new { status, message, data });
            }
            {
                bool status = false;
                var message = "No users found";
                return this.BadRequest(new { status, message });
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
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var secureToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(secureToken);
            return token;
        }
    }
}