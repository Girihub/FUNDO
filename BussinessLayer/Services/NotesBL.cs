//----------------------------------------------------
// <copyright file="NotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
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

        public string DeleteNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetNotes()
        {
            throw new System.NotImplementedException();
        }

        public string UpdateNote(int id, NotesModel notesModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
