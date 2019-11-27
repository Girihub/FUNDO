//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        string AddNote(NotesModel notesModel);

        string DeleteNote(int id);

        string GetNotes();

        string UpdateNote(int id, NotesModel notesModel);

        string GetNote(int id);
    }
}
