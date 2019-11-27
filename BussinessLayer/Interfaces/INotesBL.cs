//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        Task<string> AddNote(NotesModel notesModel);

        string DeleteNote(int id);

        string GetNotes();

        string UpdateNote(int id, NotesModel notesModel);

        string GetNote(int id);
    }
}
