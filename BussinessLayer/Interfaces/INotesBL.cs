//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        Task<string> AddNote(NotesModel notesModel);

        Task<string> DeleteNote(int id);

        IList<NotesModel> GetNotes(int UserId);

        string UpdateNote(int id, NotesModel notesModel);

        IList<NotesModel> GetNote(int id);
    }
}
