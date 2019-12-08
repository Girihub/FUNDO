//----------------------------------------------------
// <copyright file="NotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{
    using BussinessLayer.Interfaces;
    using CommonLayer.Constants;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NotesBL : INotesBL
    {
        private readonly INotesRL repository;

        public NotesBL(INotesRL repository)
        {
            this.repository = repository;
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }        

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

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
            catch (Exception E)
            {
                throw new Exception("Enter Valid Id" + E);
            }
            
        }

        public IList<NotesModel> GetNotes(int UserId)
        {
            try
            {
                return this.repository.GetNotes(UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        public IList<NotesModel> GetAllArchives(int UserId)
        {
            try
            {
                return this.repository.GetAllArchives(UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        public IList<NotesModel> GetAllTrashed(int UserId)
        {
            try
            {
                return this.repository.GetAllTrashed(UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        public IList<NotesModel> GetAllPinned(int UserId)
        {
            try
            {
                return this.repository.GetAllPinned(UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

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
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        public async Task<string> AddReminder(DateTime dateTime, int Id, int UserId)
        {
            try
            {
                if (Id > 0)
                {
                    return await this.repository.AddReminder(dateTime, Id, UserId);
                }
                else
                {
                    return "Enter valid Id";
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
    }
}
