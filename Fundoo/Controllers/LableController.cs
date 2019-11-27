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
    }
}