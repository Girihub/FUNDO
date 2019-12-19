﻿//----------------------------------------------------
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
    using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRL"/> class.
        /// </summary>
        /// <param name="appDbContext">appDBContext as a parameter</param>
        public NotesRL(AuthenticationContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
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
                    ////****** code to remove entries from NoteLabel tabel
                    var noteLabel = this.appDbContext.NoteLabel.Where(g => g.NoteId == id && g.UserId == userId).FirstOrDefault();
                    while (noteLabel != null)
                    {
                        this.appDbContext.NoteLabel.Remove(noteLabel);
                        await this.appDbContext.SaveChangesAsync();
                        noteLabel = this.appDbContext.NoteLabel.Where(g => g.NoteId == id && g.UserId == userId).FirstOrDefault();
                    }
                    ////*******

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
                    if (userId == line.UserId && line.IsArchive == false && line.IsTrash == false)
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
                        note.ModifiedDate = DateTime.Now;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note archived";
                    }
                    else
                    {
                        note.IsArchive = false;
                        note.ModifiedDate = DateTime.Now;
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
                        note.ModifiedDate = DateTime.Now;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note trashed";
                    }
                    else
                    {
                        note.IsTrash = false;
                        note.ModifiedDate = DateTime.Now;
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
                        note.ModifiedDate = DateTime.Now;
                        await this.appDbContext.SaveChangesAsync();
                        return "Note pinned";
                    }
                    else
                    {
                        note.IsPin = false;
                        note.ModifiedDate = DateTime.Now;
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
                ImageCloudinary cloudinary = new ImageCloudinary(configuration);

                 var note = this.appDbContext.Notes.Where(g => g.Id == id && g.UserId == userId).FirstOrDefault();
                if (note != null)
                {
                    note.Image = cloudinary.UploadImage(formFile);
                    note.ModifiedDate = DateTime.Now;
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
                    note.ModifiedDate = DateTime.Now;
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
                    return "Color changed";
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Method to add label in note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be added in a note</param>
        /// <param name="userId">id of user</param>
        /// <returns>returns message</returns>
        public async Task<string> AddLabel(int noteId, int labelId, int userId)
        {
            try
            {
                var note = this.appDbContext.Notes.Where(g => g.Id == noteId).FirstOrDefault();
                var label = this.appDbContext.Lables.Where(g => g.Id == labelId).FirstOrDefault();

                if (note != null && label != null)
                {
                    if (note.UserId == userId && label.UserId == userId)
                    {
                        var noteLabel = this.appDbContext.NoteLabel.Where(g => g.NoteId == note.Id && g.LabelId == label.Id).FirstOrDefault();

                        if (noteLabel == null)
                        {
                            var model = new NoteLabelModel()
                            {
                                NoteId = noteId,
                                LabelId = labelId,
                                Delete = false,
                                UserId = note.UserId
                            };
                            this.appDbContext.NoteLabel.Add(model);
                            await this.appDbContext.SaveChangesAsync();

                            ////**** Change the modified date of note
                            note.ModifiedDate = DateTime.Now;
                            await this.appDbContext.SaveChangesAsync();
                            ////****

                            return "Label added to given note";
                        }

                        return "Label already added to this note";
                    }

                    return "Note or label does not belong to this user. Check their UserIds";
                }

                return "Check if given note or label present in database";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to remove label from note
        /// </summary>
        /// <param name="noteId">id of note</param>
        /// <param name="labelId">id of label to be removed from note</param>
        /// <param name="userId">id of user</param>
        /// <returns>returns message</returns>
        public async Task<string> RemoveLabel(int noteId, int labelId, int userId)
        {
            try
            {
                var noteLabel = this.appDbContext.NoteLabel.Where(g => g.NoteId == noteId && g.LabelId == labelId).FirstOrDefault();

                if (noteLabel != null)
                {
                    if (noteLabel.UserId == userId)
                    {
                        this.appDbContext.NoteLabel.Remove(noteLabel);
                        await this.appDbContext.SaveChangesAsync();

                        ////**** Change the modified date of note
                        var note = this.appDbContext.Notes.Where(g => g.Id == noteId).FirstOrDefault();
                        note.ModifiedDate = DateTime.Now;
                        await this.appDbContext.SaveChangesAsync();
                        ////****

                        return "Label removed from note";
                    }
                }

                return "Label is not attached to this label";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to trash notes in bulk
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <param name="noteIds">Ids of notes</param>
        /// <returns>returns result</returns>
        public async Task<bool> BulkTrash(int userId, List<int> noteIds)
        {
            try
            {
                foreach (var id in noteIds)
                {
                    bool found = false;
                    foreach (var note in this.appDbContext.Notes)
                    {
                        if (id == note.Id && userId == note.UserId)
                        {
                            note.IsTrash = true;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        return false;
                    }
                }

                await this.appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to search notes by word
        /// </summary>
        /// <param name="word">word as a parameter</param>
        /// <param name="userId">Id of user</param>
        /// <returns>returns result</returns>
        public async Task<IList<NotesModel>> Search(string word, int userId)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();
                word = word.ToLower();
                foreach(var row in this.appDbContext.Notes)
                {
                    if(row.UserId == userId)
                    {
                        if (row.Title.ToLower().Contains(word) || row.Description.ToLower().Contains(word))
                        {
                            notes.Add(row);
                        }
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
        /// Method to collaborate with user
        /// </summary>
        /// <param name="usersIds">Ids of users</param>
        /// <param name="noteIds">Ids of notes</param>
        /// <param name="collaboratorId">Id of collaborator</param>
        /// <returns>returns result</returns>
        public async Task<string> Collaborate(int usersId, int noteId, int collaboratorId)
        {
            try
            {
                //// check collaborator has the access to given note id
                var note = this.appDbContext.Notes.Where(c => c.UserId == collaboratorId && c.Id == noteId).FirstOrDefault();
                if(note != null)
                {
                    if(usersId == collaboratorId)
                    {
                        return "You already have access to note " + noteId;
                    }

                    var user = this.appDbContext.Registration.Where(c => c.Id == usersId).FirstOrDefault();
                    if(user != null)
                    {
                        var colab = this.appDbContext.Collaborate.Where(c => c.CollaboratedBy == collaboratorId && c.CollaboratedWith == usersId && c.NoteId == noteId).FirstOrDefault();
                        if (colab != null)
                        {
                            return "You already have access to note " + noteId;
                        }

                        var model = new CollaborateModel()
                        {
                            CollaboratedBy = collaboratorId,
                            CollaboratedWith = usersId,
                            NoteId = noteId
                        };

                        this.appDbContext.Collaborate.Add(model);
                        await this.appDbContext.SaveChangesAsync();
                        return "Collaborate successfully...";
                    }
                    else
                    {
                        return "Check user id you want to collaborate with";
                    }
                }

                return "Check note id and user id";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}