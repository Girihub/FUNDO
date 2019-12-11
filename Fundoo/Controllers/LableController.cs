//----------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// LabelController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LableController : ControllerBase
    {
        /// <summary>
        /// private field of business interface
        /// </summary>
        private readonly ILableBL businessLable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController"/> class.
        /// </summary>
        /// <param name="businessLable">businessLabel as a parameter</param>
        public LableController(ILableBL businessLable)
        {
            this.businessLable = businessLable;
        }

        /// <summary>
        /// API for add label
        /// </summary>
        /// <param name="lableModel">labelModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        public async Task<IActionResult> AddLable(LabelRequest labelRequest)
        {
            var UserId = User.FindFirst("Id")?.Value;
            int Userid = Convert.ToInt32(UserId);
            var result = await this.businessLable.AddLable(labelRequest, Userid);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API for delete label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteLable(int id)
        {
            var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessLable.DeleteLable(id, UserId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all labels
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        public async Task<IActionResult> GetLables()
        {
            var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessLable.GetLables(UserId);
            if(result.Count != 0)
            {
                return this.Ok(new { result });
            }
            var message = "Labels not present";
            return this.Ok(new { result, message });
        }

        /// <summary>
        /// API to get label by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpGet("{id}")]
        //[Route("GetLableById")]
        public async Task<IActionResult> GetLable(int id)
        {
            var result = await this.businessLable.GetLable(id);
            var message = "Labels not present";
            if (result[0] != null)
            {
                return this.Ok(new { result });
            }            
            return this.Ok(new { result, message });
        }

        /// <summary>
        /// API to update label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="labelModel">labelModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLable(int id, LabelRequest labelRequest)
        {
            int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessLable.UpdateLable(id, labelRequest, UserId);
            return this.Ok(new { result });
        }
    }
}