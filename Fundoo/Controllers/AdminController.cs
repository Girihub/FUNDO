//----------------------------------------------------
// <copyright file="AdminController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="businessRegistration">businessRegistration as a parameter</param>
        public AdminController(IAdminBL businessRegistration)
        {
            this.businessRegistration = businessRegistration;
        }

        /// <summary>
        /// API for registration of admin
        /// </summary>
        /// <param name="registrationModel">registrationModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("AdminRegistration")]
        public async Task<IActionResult> AddAdmin(RegistrationRequest registrationRequest)
        {
            var result = await this.businessRegistration.AddAdmin(registrationRequest);
            if (result)
            {
                var message = "Registered successfully....";
                return this.Ok(new { result, message });
            }
            else
            {
                var message = "Email has already been registered. Use another email";
                return this.Ok(new { result, message });
            }
        }

        /// <summary>
        /// API for Login of admin
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result</returns>
        [HttpPost]
        [Route("AdminLogin")]
        public async Task<IActionResult> LoginAdmin(LoginModel loginModel)
        {
            var result = await this.businessRegistration.LoginAdmin(loginModel);
            if (result == null)
            {
                var flag = false;
                var message = "Enter valid email";
                return this.Ok(new { flag, message });
            }
            else if (result.Equals("!pass"))
            {
                var flag = false;
                var message = "Enter valid password";
                return this.Ok(new { flag, message });
            }
            else
            {
                var message = "Logged in successfully...";
                return this.Ok(new { message, result, });
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

            return this.Ok(new { result });
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
            var result = await this.businessRegistration.UserList(userId);

            if (result.Count != 0)
            {
                return this.Ok(new { result });
            }

            var message = "No users found";
            return this.Ok(new { result, message });
        }
    }
}