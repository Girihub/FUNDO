//----------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LableController : ControllerBase
    {
        private readonly ILableBL businessLable;

        public LableController(ILableBL businessLable)
        {
            this.businessLable = businessLable;
        }

        [HttpPost]
        [Route("AddLable")]
        public async Task<IActionResult> AddLable(LabelModel lableModel)
        {
            var result = await this.businessLable.AddLable(lableModel);
            return this.Ok(new { result });
        }

        [HttpDelete]
        [Route("DeleteLable")]
        public async Task<IActionResult> DeleteLable(int id)
        {
            var result = await this.businessLable.DeleteLable(id);
            return this.Ok(new { result});
        }

        [HttpGet]
        [Route("GetAllLables")]
        public async Task<IActionResult> GetLables()
        {
            var result = await this.businessLable.GetLables();
            return this.Ok(new { result });
        }

        [HttpGet]
        [Route("GetLableById")]
        public async Task<IActionResult> GetLable(int id)
        {
            var result = await this.businessLable.GetLable(id);
            return this.Ok(new { result });
        }

        [HttpPut]
        [Route("UpadateLable")]
        public async Task<IActionResult> UpdateLable(int id, LabelModel labelModel)
        {
            var result = await this.businessLable.UpdateLable(id, labelModel);
            return this.Ok(new { result });
        }
    }
}