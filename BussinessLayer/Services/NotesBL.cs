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

        public string UpdateNote(int id, NotesModel notesModel)
        {
            try
            {
                if(notesModel != null)
                {
                    return this.repository.UpdateNote(id, notesModel);
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
    }
}
