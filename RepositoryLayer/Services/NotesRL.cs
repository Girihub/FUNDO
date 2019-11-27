using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private readonly AuthenticationContext appDbContext;

        public NotesRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<string> AddNote(NotesModel notesModel)
        {
            throw new NotImplementedException();
        }

        public string DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public string GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public string GetNotes()
        {
            throw new NotImplementedException();
        }

        public string UpdateNote(int id, NotesModel notesModel)
        {
            throw new NotImplementedException();
        }
    }
}
