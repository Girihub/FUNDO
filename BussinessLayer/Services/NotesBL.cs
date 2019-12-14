//----------------------------------------------------
// <copyright file="NotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using BussinessLayer.Interfaces;
    using CommonLayer.Constants;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Interfaces;    

    public class NotesBL : INotesBL
    {
        private readonly INotesRL repository;

        public NotesBL(INotesRL repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method to add note in database
        /// </summary>
        /// <param name="noteRequest">noteRequest model as a parameter</param>
        /// <param name="UserId">Id of user as a parameter</param>
        /// <returns>returns result</returns>
        public async Task<string> AddNote(NoteRequest noteRequest, int UserId)
        {
            try
            {
                if(noteRequest != null)
                {
                    return await this.repository.AddNote(noteRequest, UserId);
                }
                else
                {
                    return ErrorMessages.nullModel;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }        

        /// <summary>
        /// Method to delete the note
        /// </summary>
        /// <param name="id">id of note</param>
        /// <param name="Userid">id of user</param>
        /// <returns>returns result</returns>
        public async Task<string> DeleteNote(int id, int Userid)
        {
            try
            {
                if (!id.Equals(null))
                {
                    return await this.repository.DeleteNote(id, Userid);
                }
                else
                {
                    return ErrorMessages.invalidId;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to display note byid
        /// </summary>
        /// <param name="id">id of note to be displayed</param>
        /// <returns>returns result</returns>
        public IList<NotesModel> GetNote(int id)
        {
            try
            {
                if (!id.Equals(null))
                {
                    return this.repository.GetNote(id);
                }
                else
                {
                    throw new Exception("Enter Valid Id");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Enter Valid Id" + e);
            }
            
        }

        /// <summary>
        /// Method to display notes
        /// </summary>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public IList<NotesModel> GetNotes(int UserId)
        {
            try
            {
                return this.repository.GetNotes(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to update note
        /// </summary>
        /// <param name="id">id of note to be updated</param>
        /// <param name="noteUpdate">noteUpdate model as a parameter</param>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public async Task<string> UpdateNote(int id, NoteUpdate noteUpdate, int UserId)
        {
            try
            {
                if(noteUpdate != null)
                {
                    return await this.repository.UpdateNote(id, noteUpdate, UserId);
                }
                else
                {
                    return ErrorMessages.nullModel;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        /// <summary>
        /// Method to archive the note
        /// </summary>
        /// <param name="Id">id of note to be archived</param>
        /// <param name="UserId">id os user</param>
        /// <returns>returns result</returns>
        public async Task<string> Archive(int Id, int UserId)
        {
            try
            {
                if (Id > 0)
                {
                    return await this.repository.Archive(Id, UserId);
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display archived notes
        /// </summary>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public IList<NotesModel> GetAllArchives(int UserId)
        {
            try
            {
                return this.repository.GetAllArchives(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to trash and recover note
        /// </summary>
        /// <param name="Id">id of note to be trashed or recovered</param>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public async Task<string> Trash(int Id, int UserId)
        {
            try
            {
                if(Id > 0)
                {
                    return await this.repository.Trash(Id, UserId);
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display all trashed notes
        /// </summary>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public IList<NotesModel> GetAllTrashed(int UserId)
        {
            try
            {
                return this.repository.GetAllTrashed(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to pin and unpin the note
        /// </summary>
        /// <param name="Id">id of note to be pinned or un-pinned</param>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public async Task<string> Pin(int Id, int UserId)
        {
            try
            {
                if (Id > 0)
                {
                    return await this.repository.Pin(Id, UserId);
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to display all pinned notes
        /// </summary>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public IList<NotesModel> GetAllPinned(int UserId)
        {
            try
            {
                return this.repository.GetAllPinned(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to add image
        /// </summary>
        /// <param name="formFile">formFile interface to upload desired image</param>
        /// <param name="Id">id of note</param>
        /// <param name="UserId">id of user</param>
        /// <returns>returns result</returns>
        public async Task<string> AddImage(IFormFile formFile, int Id, int UserId)
        {
            try
            {
                if (Id > 0)
                {
                    return await this.repository.AddImage(formFile, Id, UserId);
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to add reminder
        /// </summary>
        /// <param name="dateTime">date and time of reminder</param>
        /// <param name="Id">Id of note</param>
        /// <param name="UserId">Id of User</param>
        /// <returns>returns message after performing the operation</returns>
        public async Task<string> AddReminder(DateTime dateTime, int Id, int UserId)
        {
            try
            {
                if (Id > 0)
                {
                    //// Reminder should be future time
                    if(dateTime >= DateTime.Now)
                    {
                        if(dateTime.Hour >= DateTime.Now.Hour)
                        {
                            if(dateTime.Minute > DateTime.Now.Minute)
                            {
                                return await this.repository.AddReminder(dateTime, Id, UserId);
                            }
                            return "Enter future time";
                        }
                        return "Enter future time";
                    }
                    else
                    {                        
                        return "Enter future date";
                    }
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to add color
        /// </summary>
        /// <param name="id">Id of note as a parameter</param>
        /// <param name="color">color to be added</param>
        /// <param name="userId">Id of user</param>
        /// <returns>returns message in string format</returns>
        public async Task<string> ChangeColor(int Id, string color, int UserId)
        {
            try
            {
                if (!Regex.Match(color, "^(#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3}))$").Success)
                {
                    return "Enter valid color code. eg. #f02f24 or #fff";
                }
                else
                {
                    return await this.repository.ChangeColor(Id, color, UserId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                return await this.repository.AddLabel(noteId, labelId, userId);
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
                return await this.repository.RemoveLabel(noteId, labelId, userId);
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
        /// <returns>return result</returns>
        public async Task<bool> BulkTrash(int userId, List<int> noteIds)
        {
            try
            {
                return await this.repository.BulkTrash(userId, noteIds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
