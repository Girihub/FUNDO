//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using CommonLayer.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        Task<string> AddNote(NoteRequest noteRequest, int UserId);

        Task<string> DeleteNote(int id, int Userid);

        IList<NotesModel> GetNotes(int UserId);

        Task<string> UpdateNote(int id, NoteUpdate noteUpdate, int UserId);

        IList<NotesModel> GetNote(int id);
    }
}
