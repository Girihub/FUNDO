using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fundoo.Controllers
{
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
    }
}   