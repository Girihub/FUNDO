//----------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
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
    /// LabelController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("AddLable")]
        public async Task<IActionResult> AddLable(LabelModel lableModel)
        {
            var result = await this.businessLable.AddLable(lableModel);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API for delete label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete]
        [Route("DeleteLable")]
        public async Task<IActionResult> DeleteLable(int id)
        {
            var result = await this.businessLable.DeleteLable(id);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all labels
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        [Route("GetAllLables")]
        public async Task<IActionResult> GetLables()
        {
            var result = await this.businessLable.GetLables();
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get label by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpGet]
        [Route("GetLableById")]
        public async Task<IActionResult> GetLable(int id)
        {
            var result = await this.businessLable.GetLable(id);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to update label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="labelModel">labelModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPut]
        [Route("UpadateLable")]
        public async Task<IActionResult> UpdateLable(int id, LabelModel labelModel)
        {
            var result = await this.businessLable.UpdateLable(id, labelModel);
            return this.Ok(new { result });
        }
    }
}