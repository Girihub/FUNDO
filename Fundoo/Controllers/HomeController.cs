using BussinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fundoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AccountBL businessRegistration;

        public HomeController(AccountBL businessRegistration)
        {
            this.businessRegistration = businessRegistration;
        }

        [HttpPost]
        public IActionResult AddUser(RegistrationModel registrationModel)
        {
            var result = this.businessRegistration.AddUser(registrationModel);
            return this.Ok(new { result });
        }
    }
}   