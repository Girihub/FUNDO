using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstituentController : ControllerBase
    {
        private readonly IConstituentBL businessConstituent;

        public ConstituentController(IConstituentBL businessConstituent)
        {
            this.businessConstituent = businessConstituent;
        }

        [HttpPost]
        public async Task<IActionResult> AddConstituent([FromForm] ConstituentRequest constituentRequest)
        {
            try
            {
                var data = await this.businessConstituent.AddConstituent(constituentRequest);

                if (data.Name == null)
                {
                    var message = "Constituency is already present in respective state";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    var message = "Constituency added in respective state";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{constituentId}")]
        public async Task<IActionResult> DeleteConstituent(int constituentId)
        {
            try
            {
                var data = await this.businessConstituent.DeleteConstituent(constituentId);

                if (data)
                {
                    var message = "Constituency deleted";
                    bool status = true;
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "Inavalid Constituency Id";
                    bool status = false; ;
                    return this.BadRequest(new { status, message });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{constituentId}")]
        public async Task<IActionResult> UpdateConstituent(int constituentId, [FromForm] ConstituentRequest constituentRequest)
        {
            try
            {
                var data = await this.businessConstituent.UpdateConstituent(constituentId, constituentRequest);

                if (data == null)
                {
                    var message = "Invalid constituency id";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    var message = "Constituency updated....";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetConstituencies()
        {
            try
            {
                var data = this.businessConstituent.GetConstituencies();

                if(data.Count > 0)
                {
                    var message = "Following constituencies found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No constituencies found";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}