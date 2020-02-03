using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using CommonLayer.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL businessAdmin;

        private readonly IConfiguration configuration;

        public AdminController(IAdminBL businessAdmin, IConfiguration configuration)
        {
            this.businessAdmin = businessAdmin;
            this.configuration = configuration;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> AddAdmin(AdminRequest admin)
        {
            try
            {
                var data = await this.businessAdmin.AddAdmin(admin);
                if (data.MobileNumber == null)
                {
                    bool status = false;
                    var message = "Registration failed. Mobile Number already registered";
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "Registered successfully....";
                    return this.Ok(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult AdminLogin(LoginRequest loginRequest)
        {
            try
            {
                var data = this.businessAdmin.AdminLogin(loginRequest);
                if (data.MobileNumber == null)
                {
                    bool status = false;
                    var message = "Login failed. Invalid credentials";
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "Login successfull";
                    data.Token = this.GetToken(data.Id.ToString(), data.UserName);
                    return this.Ok(new { status, message, data });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

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