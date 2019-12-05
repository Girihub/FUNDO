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
        public async Task<IActionResult> AddNote(NotesModel notesModel)
        {
            var UserId = User.FindFirst("Id")?.Value;
            notesModel.UserId = Convert.ToInt32(UserId);
            var result = await this.businessNotes.AddNote(notesModel);
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
        public IActionResult UpdateNote(int id, NotesModel notesModel)
        {
            var UserId = User.FindFirst("Id")?.Value;
            notesModel.UserId = Convert.ToInt32(UserId);
            var result = this.businessNotes.UpdateNote(id, notesModel);
            return this.Ok(new { result });
        }
    }
}