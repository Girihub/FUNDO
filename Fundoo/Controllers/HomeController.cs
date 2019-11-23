

namespace Fundoo.Controllers
{
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountBL _businessRegistration;

        public HomeController(IAccountBL businessRegistration)
        {
            this._businessRegistration = businessRegistration;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> AddUser(RegistrationModel registrationModel)
        {
            var result = await this._businessRegistration.AddUser(registrationModel);
            return Ok(new { result });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            var result = await this._businessRegistration.LoginUser(loginModel);
            return Ok(new { result });
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            var result = this._businessRegistration.ForgotPassword(forgotPassword);
            return Ok(new { result });
        }
    }
}   