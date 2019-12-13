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
    using CloudinaryDotNet;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddNote(NoteRequest noteRequest)
        {
            ////getting the Id of note from token
            var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.AddNote(noteRequest, UserId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API for delete note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            ////getting the Id of note from token
            var userid = User.FindFirst("Id")?.Value;
            int userId = Convert.ToInt32(userid);
            var result = await this.businessNotes.DeleteNote(id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all notes
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            ////getting the Id of note from token
            var userid = User.FindFirst("Id")?.Value;
            int userId = Convert.ToInt32(userid);
            var result = this.businessNotes.GetNotes(userId);
            
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get note by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpGet]
        [Route("{id}")]
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
        [Route("{id }")]
        public async Task<IActionResult> UpdateNote(int id, NoteUpdate noteUpdate)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.UpdateNote(id, noteUpdate, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to archive and unarchive note
        /// </summary>
        /// <param name="Id">Id of note as a parameter</param>
        /// <returns>returns result</returns>
        [HttpPost("{id}/Archive")]
        public async Task<IActionResult> Archive(int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.Archive(id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to display all archived notes
        /// </summary>
        /// <returns>returns all archived notes</returns>
        [HttpGet]
        [Route("GetAllArchives")]
        public IActionResult GetAllArchives()
        {
            ////getting the Id of note from token
            var userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = this.businessNotes.GetAllArchives(userId);
            if (result.Count != 0)
            {
                return this.Ok(new { result });
            }
            var message = "No archived notes";
            return this.Ok(new { result, message });
        }

        /// <summary>
        /// API to trash and to recover note
        /// </summary>
        /// <param name="Id">Id of note to be trashed or recovered</param>
        /// <returns>returns result</returns>
        [HttpPost("{id}/Trash")]
        public async Task<IActionResult> Trash(int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.Trash(id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all trashed notes
        /// </summary>
        /// <returns>returns all trashed notes if there is any in trash otherwise returns message</returns>
        [HttpGet("GetAllTrashed")]
        public IActionResult GetAllTrashed()
        {
            ////getting the Id of note from token
            var userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = this.businessNotes.GetAllTrashed(userId);
            if (result.Count != 0)
            {
                return this.Ok(new { result });
            }
            var message = "No trashed notes";
            return this.Ok(new { result, message });
        }

        /// <summary>
        /// API to pin and unpin note
        /// </summary>
        /// <param name="Id">Id of note to be pinned or unpinned</param>
        /// <returns>returns message after performing the operation</returns>
        [HttpPost("{id}/Pin")]
        public async Task<IActionResult> Pin(int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.Pin(id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to get all pinned notes
        /// </summary>
        /// <returns>returns all pinned notes</returns>
        [HttpGet("GetAllPinned")]
        public IActionResult GetAllPinned()
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = this.businessNotes.GetAllPinned(userId);
            if (result.Count != 0)
            {
                return this.Ok(new { result });
            }
            var message = "No pinned notes";
            return this.Ok(new { result, message });
        }

        /// <summary>
        /// API to add image
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <param name="Id">Id of note to which image to be added</param>
        /// <returns>retuns message after performing the operation</returns>
        [HttpPost("{id}/AddImage")]
        public async Task<IActionResult> AddImage(IFormFile formFile, int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.AddImage(formFile, id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to add reminder in note
        /// </summary>
        /// <param name="dateTime">date and time of reminder for note</param>
        /// <param name="Id">Id of note</param>
        /// <returns>returns the message</returns>
        [HttpPost("{id}/AddReminder")]
        public async Task<IActionResult> AddReminder(DateTime dateTime, int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.AddReminder(dateTime, id, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to add color to note
        /// </summary>
        /// <param name="color">color as a parameter</param>
        /// <returns>returns the message</returns>
        [HttpPatch("{id}/ChangeColor")]
        public async Task<IActionResult> ChangeColor(int id, string color)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.ChangeColor(id, color, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to add label in note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be added in note</param>
        /// <returns>returns message</returns>
        [HttpPost("{noteId}/Label/{labelId}")]
        public async Task<IActionResult> AddLabel(int noteId, int labelId)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.AddLabel(noteId, labelId, userId);
            return this.Ok(new { result });
        }

        /// <summary>
        /// API to remove label from note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be removed from note</param>
        /// <returns>returns message</returns>
        [HttpDelete("{noteId}/Label/{labelId}")]
        public async Task<IActionResult> RemoveLabel(int noteId, int labelId)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var result = await this.businessNotes.RemoveLabel(noteId, labelId, userId);
            return this.Ok(new { result });
        }
    }
}