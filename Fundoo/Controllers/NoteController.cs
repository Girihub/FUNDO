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
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INotesBL businessNotes;

        public NoteController(INotesBL businessNotes)
        {
            this.businessNotes = businessNotes;
        }

        [HttpPost]
        [Route("AddNote")]
        public async Task<IActionResult> AddNote(NotesModel notesModel)
        {
            var result = await this.businessNotes.AddNote(notesModel);
            return this.Ok(new { result });
        }

        [HttpDelete]
        [Route("DeleteNote")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var result = await this.businessNotes.DeleteNote(id);
            return this.Ok(new { result });
        }

        [HttpGet]
        [Route("GetNotes")]
        public IActionResult GetNotes()
        {
            var result = this.businessNotes.GetNotes();
            return this.Ok(new { result });
        }

        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNote(int id)
        {
            var result = this.businessNotes.GetNote(id);
            return this.Ok(new { result });
        }
    }
}