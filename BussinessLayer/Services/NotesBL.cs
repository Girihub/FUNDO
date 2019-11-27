﻿//----------------------------------------------------
// <copyright file="NotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL repository;

        public NotesBL(INotesRL repository)
        {
            this.repository = repository;
        }

        public async Task<string> AddNote(NotesModel notesModel)
        {
            return await this.repository.AddNote(notesModel);
        }

        public async Task<string> DeleteNote(int id)
        {
            return await this.repository.DeleteNote(id);
        }

        public IList<NotesModel> GetNote(int id)
        {
            return this.repository.GetNote(id);
        }

        public IList<NotesModel> GetNotes()
        {
            return this.repository.GetNotes();
        }

        public string UpdateNote(int id, NotesModel notesModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
