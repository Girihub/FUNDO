//----------------------------------------------------
// <copyright file="INotesRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        string AddNote(NotesModel notesModel);

        string DeleteNote(int id);

        string GetNotes();

        string UpdateNote(int id, NotesModel notesModel);

        string GetNote(int id);
    }
}
