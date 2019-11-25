//----------------------------------------------------
// <copyright file="ValuesController.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace Fundoo.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ValuesController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// API to get data
        /// </summary>
        /// <returns>returns values in JSON</returns>
        //// GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// API to get data by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns values in JSON</returns>
        //// GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// API to Post data by id
        /// </summary>
        /// <param name="value">value as a parameter</param>
        //// GET api/values
        //// POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// API to Put data by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="value">value as a parameter</param>
        //// GET api/values/5
        //// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// API to delete data by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
