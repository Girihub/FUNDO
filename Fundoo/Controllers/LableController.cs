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
            try
            {
                var UserId = User.FindFirst("Id")?.Value;
                int Userid = Convert.ToInt32(UserId);
                var data = await this.businessLable.AddLable(labelRequest, Userid);
                bool status = true;
                var message = "Label added successfully";
                return this.Ok(new { status, message, data });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API for delete label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLable(int id)
        {
            try
            {
                var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var result = await this.businessLable.DeleteLable(id, UserId);
                if (result)
                {
                    bool status = true;
                    var message = "Label deleted";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = false;
                    var message = "Label not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to get all labels
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        public async Task<IActionResult> GetLables()
        {
            try
            {
                var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessLable.GetLables(UserId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following are the labels";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Labels not present";
                    return this.BadRequest(new { status, message });
                }
            }  
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            try
            {
                var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessLable.GetLable(id, UserId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following label found";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Label not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to update label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="labelModel">labelModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLable(int id, [FromForm] LabelRequest labelRequest)
        {
            try
            {
                int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessLable.UpdateLable(id, labelRequest, UserId);
                if (data.Lable != null)
                {
                    bool status = true;
                    var message = "Following label updated";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Label not found";
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