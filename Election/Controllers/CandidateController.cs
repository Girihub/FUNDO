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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateBL businessCandidate;

        public CandidateController(ICandidateBL businessCandidate)
        {
            this.businessCandidate = businessCandidate;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromForm] CandidateRequest candidateRequest)
        {
            try
            {
                var data = await this.businessCandidate.AddCandidate(candidateRequest);

                if (data.FirstName == null)
                {
                    var message = "Candidate already present or Party is already present in respective constituency or party or constituency not present";
                    bool status = false;
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    var message = "Candidate added";
                    bool status = true;
                    return this.Ok(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{candidateId}")]
        public async Task<IActionResult> DeleteCandidate(int candidateId)
        {
            try
            {
                var data = await this.businessCandidate.DeleteCandidate(candidateId);

                if (data)
                {
                    bool status = true;
                    var message = "Candidate deleted successfully...";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = false;
                    var message = "Invalid Id";
                    return this.BadRequest(new { status, message });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{candidateId}")]
        public async Task<IActionResult> UpdateCandidate(int candidateId, [FromForm] CandidateRequest candidateRequest)
        {
            try
            {
                var data = await this.businessCandidate.UpdateCandidate(candidateId, candidateRequest);

                if (data.FirstName == null)
                {
                    bool status = false;
                    var message = "Enter valid Ids";
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "Candidate updated successfully....";
                    return this.Ok(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCandidates()
        {
            try
            {
                var data = this.businessCandidate.GetCandidates();

                if (data.Count > 0)
                {
                    var message = "Following candidates found";
                    bool status = true;
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var message = "No candidates found";
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