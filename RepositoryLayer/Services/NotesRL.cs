//----------------------------------------------------
// <copyright file="NotesRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;        

    /// <summary>
    /// NotesRL as a class
    /// </summary>
    public class NotesRL : INotesRL
    {
        /// <summary>
        /// private field appDBContext to access database
        /// </summary>
        private readonly AuthenticationContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRL"/> class.
        /// </summary>
        /// <param name="appDbContext">appDBContext as a parameter</param>
        public NotesRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Method to add note in table
        /// </summary>
        /// <param name="notesModel">notesModel as a parameter</param>
        /// <returns>returns string value</returns>
        public async Task<string> AddNote(NoteRequest noteRequest, int UserId)
        {
            try
            {
                var note = new NotesModel()
                {
                    Title = noteRequest.Title,
                    Description = noteRequest.Description,
                    Image = noteRequest.Image,
                    Color = noteRequest.Color,
                    IsPin = noteRequest.IsPin,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    AddReminder = noteRequest.AddReminder,
                    UserId = UserId,
                    IsNote = noteRequest.IsNote,
                    IsArchive = false,
                    IsTrash = false                    
            };
                this.appDbContext.Notes.Add(note);
                var result = await this.appDbContext.SaveChangesAsync();
                return "Note added";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to delete note from table
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in string</returns>
        public async Task<string> DeleteNote(int id, int Userid)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == Userid).FirstOrDefault();

                if (notes != null)
                {
                    this.appDbContext.Notes.Remove(notes);
                    var result = await this.appDbContext.SaveChangesAsync();
                    return "Note deleted";
                }

                return "Note not found";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to get note from table by passing id as a parameter
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns required 
        /// note in list format</returns>
        public IList<NotesModel> GetNote(int id)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();
                var note = this.appDbContext.Notes.Where(g => g.Id == id).FirstOrDefault();
                    notes.Add(note);
                    return notes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to display all notes
        /// </summary>
        /// <returns>returns all notes</returns>
        public IList<NotesModel> GetNotes(int UserId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var line in this.appDbContext.Notes)
                {
                    if(UserId == line.UserId)
                    {
                        notes.Add(line);
                    }
                }

                return notes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to update note
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="notesModel">notesModel as a parameter</param>
        /// <returns>returns result in string format</returns>
        public async Task<string> UpdateNote(int id, NoteUpdate noteUpdate, int UserId)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == UserId).FirstOrDefault();
                
                if (notes == null)
                {
                    return "Enter valid Id";
                } 
                if(noteUpdate.Title != null)
                {
                    notes.Title = noteUpdate.Title;
                }
                if (noteUpdate.Description != null)
                {
                    notes.Description = noteUpdate.Description;
                }
                if (noteUpdate.Image != null)
                {
                    notes.Image = noteUpdate.Image;
                }
                if (noteUpdate.Color != null)
                {
                    notes.Color = noteUpdate.Color;
                }
                notes.IsPin = noteUpdate.IsPin;
                notes.ModifiedDate = DateTime.Now;
                notes.AddReminder = noteUpdate.AddReminder;
                notes.IsNote = noteUpdate.IsNote;
                notes.IsArchive = noteUpdate.IsArchive;
                notes.IsTrash = noteUpdate.IsTrash;
                this.appDbContext.Entry(notes).State = EntityState.Modified;
                await this.appDbContext.SaveChangesAsync();
                return "Updated";                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
