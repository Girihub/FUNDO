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
    public class VotingController : ControllerBase
    {
        private readonly IVotingBL businessVoting;

        public VotingController(IVotingBL businessVoting)
        {
            this.businessVoting = businessVoting;
        }

        [HttpPost("Vote")]
        public async Task<IActionResult> Vote([FromForm] VotingRequest votingRequest)
        {
            try
            {
                var data = await this.businessVoting.Vote(votingRequest);

                if (data.FirstName == null)
                {
                    var message = "Either you voted already or the candidate Id you provided is not present";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    var message = "Voting done";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReElection()
        {
            try
            {
                var data = await this.businessVoting.ReElection();

                if (data)
                {
                    var message = "Voting tabel clear";
                    bool status = true;
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "Voting tabel is already clear";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{constituencyId}")]
        public IActionResult ConstituencyWiseResult(int constituencyId)
        {
            try
            {
                var data = this.businessVoting.ConstituencyWiseResult(constituencyId);

                if (data.Count > 0)
                {
                    var message = "Following result found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No result found. Check constituency id";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("PartyWiseResult")]
        public IActionResult PartyWiseResultState(string state)
        {
            try
            {
                var data = this.businessVoting.PartWiseResultState(state);

                if (data.Count > 0)
                {
                    var message = "Following result found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No result found. Check state name";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("PartyWiseAll")]
        public IActionResult PartyWiseAll()
        {
            try
            {
                var data = this.businessVoting.PartyWiseAll();

                if (data.Count > 0)
                {
                    var message = "Following result found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No result found";
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