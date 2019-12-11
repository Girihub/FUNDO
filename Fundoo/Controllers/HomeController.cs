﻿//----------------------------------------------------
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
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;    

    /// <summary>
    /// HomeController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// private field of business interface
        /// </summary>
        private readonly IAccountBL businessRegistration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="businessRegistration">businessRegistration as a parameter</param>
        public HomeController(IAccountBL businessRegistration)
        {
            this.businessRegistration = businessRegistration;
        }

        /// <summary>
        /// API for registration of user
        /// </summary>
        /// <param name="registrationModel">registrationModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> AddUser(RegistrationModel registrationModel)
        {
            var result = await this.businessRegistration.AddUser(registrationModel);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API for Login of user
        /// </summary>
        /// <param name="loginModel">loginModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            var result = await this.businessRegistration.LoginUser(loginModel);
            return this.Ok(new { result });
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
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to reset password of user
        /// </summary>
        /// <param name="resetPassword">resetPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            var result = this.businessRegistration.ResetPassword(resetPassword);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get password of user
        /// </summary>
        /// <param name="getPassword">getPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("GetPassword")]
        public IActionResult GetPassword(GetPasswordModel getPassword)
        {
            var result = this.businessRegistration.GetPassword(getPassword);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to reset forgotten password of user
        /// </summary>
        /// <param name="resetForgetPassword">resetForgetPassword as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("ResetForgotPassword")]
        public async Task<IActionResult> ResetForgetPassword(ResetForgetPasswordModel resetForgetPassword)
        {
            var result = await this.businessRegistration.ResetForgetPassword(resetForgetPassword);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to upload profile picture
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost("UploadProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile formFile)
        {
            ////getting the Id of note from token
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);

            ////alternate code to get id from token
            ////int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);

            var result = await this.businessRegistration.UploadProfilePicture(id, formFile);
            return this.Ok(new { result });
        }
    }
}   