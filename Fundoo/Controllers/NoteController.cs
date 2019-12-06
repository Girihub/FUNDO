//----------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
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
    /// NoteController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// private field of business interface
        /// </summary>
        private readonly INotesBL businessNotes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteController"/> class.
        /// </summary>
        /// <param name="businessNotes">businessNotes as a parameter</param>
        public NoteController(INotesBL businessNotes)
        {
            this.businessNotes = businessNotes;
        }

        /// <summary>
        /// API for add note
        /// </summary>
        /// <param name="notesModel">notesModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        [Route("AddNote")]
        public async Task<IActionResult> AddNote(NoteRequest noteRequest)
        {
            var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.AddNote(noteRequest, UserId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API for delete note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete]
        [Route("DeleteNote")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var UserId = User.FindFirst("Id")?.Value;
            var Userid = Convert.ToInt32(UserId);
            var result = await this.businessNotes.DeleteNote(id, Userid);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all notes
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        [Route("GetNotes")]
        public IActionResult GetNotes()
        {
            var UserId = User.FindFirst("Id")?.Value;
            var Userid = Convert.ToInt32(UserId);
            var result = this.businessNotes.GetNotes(Userid);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get note by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNote(int id)
        {
            var result = this.businessNotes.GetNote(id);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to update note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="notesModel">notesModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPut]
        [Route("UpdateNote")]
        public async Task<IActionResult> UpdateNote(int id, NoteUpdate noteUpdate)
        {
            int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.UpdateNote(id, noteUpdate, UserId);
            return this.Ok(new { result });
        }

        [HttpPut]
        [Route("Archive")]
        public async Task<IActionResult> Archive(int Id)
        {
            int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.Archive(Id, UserId);
            return this.Ok(new { result });
        }

        [HttpPut]
        [Route("UnArchive")]
        public async Task<IActionResult> UnArchive(int Id)
        {
            int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.UnArchive(Id, UserId);
            return this.Ok(new { result });
        }
    }
}