//----------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
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
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NoteController class to implement API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("CorsPolicy")]
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
        /// <param name="noteRequest">noteRequest as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPost]
        public async Task<IActionResult> AddNote(NoteRequest noteRequest)
        {
            try
            {
                ////getting the Id of note from token
                var UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.AddNote(noteRequest, UserId);
                bool status = true;
                var message = "Note added successfully...";
                return this.Ok(new { status, message, data });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API for delete note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                ////getting the Id of note from token
                var userid = User.FindFirst("Id")?.Value;
                int userId = Convert.ToInt32(userid);
                var result = await this.businessNotes.DeleteNote(id, userId);
                if (result)
                {
                    bool status = true;
                    var message = "Note deleted";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = false;
                    var message = "Note not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to get all notes
        /// </summary>
        /// <returns>return result in JSON format</returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            try
            {
                ////getting the Id of note from token
                var userid = User.FindFirst("Id")?.Value;
                int userId = Convert.ToInt32(userid);

                var data = this.businessNotes.GetNotes(userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following notes found";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Notes not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            try
            {
                ////getting the Id of note from token
                var userid = User.FindFirst("Id")?.Value;
                int userId = Convert.ToInt32(userid);

                var data = this.businessNotes.GetNote(id, userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following notes found";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Notes not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to update note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="notesModel">notesModel as a parameter</param>
        /// <returns>returns result in JSON format</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromForm] NoteUpdate noteUpdate)
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.UpdateNote(id, noteUpdate, userId);
                if (data.Title != null)
                {
                    bool status = true;
                    var message = "Following note updated";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "Note not found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to archive and unarchive note
        /// </summary>
        /// <param name="Id">Id of note as a parameter</param>
        /// <returns>returns result</returns>
        [HttpPost("{id}/Archive")]
        public async Task<IActionResult> Archive(int id)
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.Archive(id, userId);
                if (data.Equals("!found"))
                {
                    bool status = false;
                    data = "Enter valid note id";
                    return this.BadRequest(new { status, data });
                }
                else
                {
                    bool status = true;
                    return this.Ok(new { status, data });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to display all archived notes
        /// </summary>
        /// <returns>returns all archived notes</returns>
        [HttpGet]
        [Route("Archived")]
        public IActionResult GetAllArchives()
        {
            try
            {
                ////getting the Id of note from token
                var userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = this.businessNotes.GetAllArchives(userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following are archived notes";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "No archived notes found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to trash and to recover note
        /// </summary>
        /// <param name="Id">Id of note to be trashed or recovered</param>
        /// <returns>returns result</returns>
        [HttpPost("{id}/Trash")]
        public async Task<IActionResult> Trash(int id)
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.Trash(id, userId);
                if (data.Equals("!found"))
                {
                    bool status = false;
                    data = "Enter valid note id";
                    return this.BadRequest(new { status, data });
                }
                else
                {
                    bool status = true;
                    return this.Ok(new { status, data });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to get all trashed notes
        /// </summary>
        /// <returns>returns all trashed notes if there is any in trash otherwise returns message</returns>
        [HttpGet("Trashed")]
        public IActionResult GetAllTrashed()
        {
            try
            {
                ////getting the Id of note from token
                var userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = this.businessNotes.GetAllTrashed(userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following are trashed notes";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "No trashed notes found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to pin and unpin note
        /// </summary>
        /// <param name="Id">Id of note to be pinned or unpinned</param>
        /// <returns>returns message after performing the operation</returns>
        [HttpPost("{id}/Pin")]
        public async Task<IActionResult> Pin(int id)
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.Pin(id, userId);
                if (data.Equals("!found"))
                {
                    bool status = false;
                    data = "Enter valid note id";
                    return this.BadRequest(new { status, data });
                }
                else
                {
                    bool status = true;
                    return this.Ok(new { status, data });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to get all pinned notes
        /// </summary>
        /// <returns>returns all pinned notes</returns>
        [HttpGet("Pinned")]
        public IActionResult GetAllPinned()
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = this.businessNotes.GetAllPinned(userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following are pinned notes";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "No pinned notes found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to add image
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <param name="Id">Id of note to which image to be added</param>
        /// <returns>retuns message after performing the operation</returns>
        [HttpPost("{id}/Image")]
        public async Task<IActionResult> AddImage(IFormFile formFile, int id)
        {
            ////getting the Id of note from token
            int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var data = await this.businessNotes.AddImage(formFile, id, userId);
            try
            {
                if (data != null)
                {
                    var status = true;
                    var message = "image added successfully";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    var status = false;
                    var message = "Enter valid note id";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to add reminder in note
        /// </summary>
        /// <param name="dateTime">date and time of reminder for note</param>
        /// <param name="Id">Id of note</param>
        /// <returns>returns the message</returns>
        [HttpPost("{id}/Reminder")]
        public async Task<IActionResult> AddReminder(ReminderRequest reminderRequest, int id)
        {
            try
            {
                ////getting the Id of note from token
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.AddReminder(reminderRequest, id, userId);
                if (data.Equals("id"))
                {
                    bool status = false;
                    var message = "Enter valid note id";
                    return this.BadRequest(new { status, message });
                }
                else if (data.Equals("time"))
                {
                    bool status = false;
                    var message = "reminder should not be past or current time";
                    return this.BadRequest(new { status, message });
                }
                else if(reminderRequest.Reminder == null)
                {
                    bool status = true;
                    var message = "reminder removed";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "reminder added on " + data;
                    return this.Ok(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to get all remindered notes
        /// </summary>
        /// <returns>returns all remindered notes if there is any in trash otherwise returns message</returns>
        [HttpGet("Remindered")]
        public IActionResult ReminderedNotes()
        {
            try
            {
                ////getting the Id of note from token
                var userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = this.businessNotes.ReminderedNotes(userId);
                if (data.Count != 0)
                {
                    bool status = true;
                    var message = "Following are remindered notes";
                    return this.Ok(new { status, message, data });
                }
                else
                {
                    bool status = false;
                    var message = "No remindered notes found";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to add color to note
        /// </summary>
        /// <param name="color">color as a parameter</param>
        /// <returns>returns the message</returns>
        [HttpPatch("{id}/ChangeColor")]
        public async Task<IActionResult> ChangeColor(int id, ColorModel colorModel)
        {
            try
            {
                ////getting the Id of note from token
                var color = colorModel.Color;
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var data = await this.businessNotes.ChangeColor(id, color, userId);
                if (data.Equals("id"))
                {
                    bool status = false;
                    var message = "Enter valid note id";
                    return this.BadRequest(new { status, message });
                }
                else if (data.Equals("code"))
                {
                    bool status = false;
                    var message = "Enter valid color code";
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "Color changed to " + data;
                    return this.Ok(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to add label in note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be added in note</param>
        /// <returns>returns message</returns>
        [HttpPost("Note/{noteId}/Label/{labelId}")]
        public async Task<IActionResult> AddLabel(int noteId, int labelId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var status = await this.businessNotes.AddLabel(noteId, labelId, userId);
                if (status)
                {
                    var message = "Label added to given note";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "invalid noteid and labelid";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to remove label from note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be removed from note</param>
        /// <returns>returns message</returns>
        [HttpDelete("Note/{noteId}/Label/{labelId}")]
        public async Task<IActionResult> RemoveLabel(int noteId, int labelId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                var status = await this.businessNotes.RemoveLabel(noteId, labelId, userId);
                if (status)
                {
                    var message = "Label removed from note";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "invalid noteid and labelid";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API for bulk trash
        /// </summary>
        /// <param name="noteIds">noteIds as a parameter</param>
        /// <returns>returns result</returns>
        [HttpPost("BulkTrash")]
        public async Task<IActionResult> BulkTrash(List<int> noteIds)
        {
            try
            {
                int userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
                var status = await this.businessNotes.BulkTrash(userId, noteIds);
                if (status)
                {
                    var message = "Notes trashed successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "Enter valid note Ids";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }    
        
        /// <summary>
        /// API to search the notes
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string word)
        {
            try
            {
                int userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
                var data = await this.businessNotes.Search(word, userId);
                if (data.Count == 0)
                {
                    bool status = false;
                    var message = "No notes found by word " + word;
                    return this.BadRequest(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "Following notes contain " + word;
                    return this.Ok(new { status, message, data });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// API to collaborate with other users
        /// </summary>
        /// <param name="usersId">Id of user</param>
        /// <param name="noteId">Id of note</param>
        /// <returns>returns result</returns>
        [HttpPost("Collaborate")]
        public async Task<IActionResult> Collaborate(int collaberateWith, int noteId)
        {
            try
            {
                int collaboratorId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
                var status = await this.businessNotes.Collaborate(collaberateWith, noteId, collaboratorId);
                if (status)
                {
                    var message = "Colaborate successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var message = "Invalid ids";
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