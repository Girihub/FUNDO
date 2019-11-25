//----------------------------------------------------
// <copyright file="HomeController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
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
    }
}   