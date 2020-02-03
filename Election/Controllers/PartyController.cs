using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyBL businessParty;

        public PartyController(IPartyBL businessParty)
        {
            this.businessParty = businessParty;
        }

        [HttpPost]
        public async Task<IActionResult> AddParty([FromForm] PartyRequest partyRequest)
        {
            try
            {
                var data = await this.businessParty.AddParty(partyRequest);
                if (data.PartyName == null)
                {
                    var message = "Party already exist";
                    bool status = false;
                    return this.BadRequest(new { message, status });
                }
                else
                {
                    var message = "Party added";
                    bool status = true;
                    return this.Ok(new { message, status, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{partyId}")]
        public async Task<IActionResult> DeleteParty(int partyId)
        {
            try
            {
                var data = await this.businessParty.DeleteParty(partyId);

                if (data)
                {
                    var message = "Party deleted successfully....";
                    bool status = true;
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "Invalid party Id";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{partyId}")]
        public async Task<IActionResult> UpdateParty(int partyId, [FromForm]PartyRequest partyRequest)
        {
            try
            {
                var data = await this.businessParty.UpdateParty(partyId, partyRequest);
                if (data.Id != 0)
                {
                    var message = "Party updated successfully...";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "Invalid partyId";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetParties()
        {
            try
            {
                var data = this.businessParty.GetParties();

                if(data.Count != 0)
                {
                    var message = "Following parties found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No parties found";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}