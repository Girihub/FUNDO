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
    using CloudinaryDotNet;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;
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
        /// <param name="noteRequest">noteRequest parameter</param>
        /// <param name="userId">userId parameter</param>
        /// <returns>returns string value</returns>
        public async Task<string> AddNote(NoteRequest noteRequest, int userId)
        {
            try
            {            
                var note = new NotesModel()
                {
                    Title = noteRequest.Title,
                    Description = noteRequest.Description,
                    Image = noteRequest.Image,
                    Color = noteRequest.Color,
                    IsPin = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    AddReminder = noteRequest.AddReminder,
                    UserId = userId,
                    IsNote = noteRequest.IsNote,
                    IsArchive = false,
                    IsTrash = false                    
            };
                this.appDbContext.Notes.Add(note);
                await this.appDbContext.SaveChangesAsync();
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
        /// <param name="userId">userId as a parameter</param>
        /// <returns>returns result in string</returns>
        public async Task<string> DeleteNote(int id, int userId)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();

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
        /// <returns>returns required note in list format</returns>
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
        /// <param name="userId">userId as a parameter</param>
        /// <returns>returns all notes</returns>
        public IList<NotesModel> GetNotes(int userId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var line in this.appDbContext.Notes)
                {
                    if (userId == line.UserId)
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
        /// <param name="noteUpdate">noteUpdate as a parameter</param>
        /// <param name="userId">userId as a parameter</param>
        /// <returns>returns result in string format</returns>
        public async Task<string> UpdateNote(int id, NoteUpdate noteUpdate, int userId)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();
                
                if (notes == null)
                {
                    return "Enter valid Id";
                } 

                if (noteUpdate.Title != null)
                {
                    notes.Title = noteUpdate.Title;
                }

                if (noteUpdate.Description != null)
                {
                    notes.Description = noteUpdate.Description;
                }

                notes.ModifiedDate = DateTime.Now;
                this.appDbContext.Entry(notes).State = EntityState.Modified;
                await this.appDbContext.SaveChangesAsync();
                return "Updated";                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to archive and un-archive note
        /// </summary>
        /// <param name="id">Id of note to be archived or un-archived</param>
        /// <param name="userId">Id of User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> Archive(int id, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();
                if (note != null)
                {
                    if (note.IsArchive == false)
                    {
                        note.IsArchive = true;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note archived";
                    }
                    else
                    {
                        note.IsArchive = false;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note unarchived";
                    }
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display all archived notes
        /// </summary>
        /// <param name="userId">Id of User as a parameter</param>
        /// <returns>returns all the archived notes</returns>
        public IList<NotesModel> GetAllArchives(int userId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var line in this.appDbContext.Notes)
                {
                    if (userId == line.UserId && line.IsArchive == true && line.IsTrash == false)
                    {
                        notes.Add(line);
                    }
                }

                return notes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to trash or recover the give note
        /// </summary>
        /// <param name="id">Id of note to be trashed or recovered</param>
        /// <param name="userId">Id of User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> Trash(int id, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();

                if (note != null)
                {
                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note trashed";
                    }
                    else
                    {
                        note.IsTrash = false;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note restored";
                    }
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to get all trashed notes
        /// </summary>
        /// <param name="userId">Id of User</param>
        /// <returns>returns all trashed notes</returns>
        public IList<NotesModel> GetAllTrashed(int userId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var row in this.appDbContext.Notes)
                {
                    if (row.UserId == userId && row.IsTrash == true)
                    {
                        notes.Add(row);
                    }
                }

                return notes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to pin and unpin the given note
        /// </summary>
        /// <param name="id">Id of note to be pinned or unpinned</param>
        /// <param name="userId">Id of User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> Pin(int id, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();

                if (note != null)
                {
                    if (note.IsPin == false)
                    {
                        note.IsPin = true;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note pinned";
                    }
                    else
                    {
                        note.IsPin = false;
                        this.appDbContext.Entry(note).State = EntityState.Modified;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note unpinned";
                    }
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to get all pinned notes
        /// </summary>
        /// <param name="userId">Id of User</param>
        /// <returns>returns all the pinned notes</returns>
        public IList<NotesModel> GetAllPinned(int userId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var row in this.appDbContext.Notes)
                {
                    if (row.UserId == userId && row.IsPin == true && row.IsTrash == false && row.IsArchive == false)
                    {
                        notes.Add(row);
                    }
                }

                return notes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to add the image
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <param name="id">Id of note in which image to be added</param>
        /// <param name="userId">Id of logged in User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> AddImage(IFormFile formFile, int id, int userId)
        {
            try
            {
                ImageCloudinary cloudiNary = new ImageCloudinary();
                Account account = new Account(cloudiNary.CLOUD_NAME, cloudiNary.API_KEY, cloudiNary.API_SECCRET_KEY);
                cloudiNary.cloudinary = new Cloudinary(account);

                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();
                if (note != null)
                {
                    note.Image = cloudiNary.UploadImage(formFile);
                    await this.appDbContext.SaveChangesAsync();
                    return "Image uploaded successfully";
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Method to add the reminder
        /// </summary>
        /// <param name="dateTime">date and time of reminder</param>
        /// <param name="id">Id of note</param>
        /// <param name="userId">Id of User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> AddReminder(DateTime dateTime, int id, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();

                if (note != null)
                {
                    note.AddReminder = dateTime;
                    await this.appDbContext.SaveChangesAsync();
                    return "Reminder added";
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Method to add color
        /// </summary>
        /// <param name="id">Id of note as a parameter</param>
        /// <param name="color">color to be added</param>
        /// <param name="userId">Id of user</param>
        /// <returns>returns message in string format</returns>
        public async Task<string> ChangeColor(int id, string color, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();

                if (note != null)
                {
                    note.Color = color;
                    note.ModifiedDate = DateTime.Now;
                    this.appDbContext.Entry(note).State = EntityState.Modified;
                    await this.appDbContext.SaveChangesAsync();
                    return "Color added";
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
