//----------------------------------------------------
// <copyright file="INotesRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        Task<string> AddNote(NotesModel notesModel);

        Task<string> DeleteNote(int id, int Userid);

        IList<NotesModel> GetNotes(int UserId);

        string UpdateNote(int id, NotesModel notesModel);

        IList<NotesModel> GetNote(int id);
    }
}
