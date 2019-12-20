//----------------------------------------------------
// <copyright file="INotesRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Interfaces
{
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INotesRL
    {
        Task<NotesModel> AddNote(NoteRequest noteRequest, int userId);

        Task<bool> DeleteNote(int id, int userId);

        IList<NotesModel> GetNotes(int userId);

        Task<NotesModel> UpdateNote(int id, NoteUpdate noteUpdate, int userId);

        IList<NotesModel> GetNote(int id, int userId);

        Task<string> Archive(int id, int userId);

        IList<NotesModel> GetAllArchives(int userId);

        Task<string> Trash(int id, int userId);

        IList<NotesModel> GetAllTrashed(int userId);

        Task<string> Pin(int id, int userId);

        IList<NotesModel> GetAllPinned(int userId);

        Task<string> AddImage(IFormFile formFile, int id, int userId);

        Task<string> AddReminder(DateTime dateTime, int id, int userId);

        Task<string> ChangeColor(int id, string color, int userId);

        Task<string> AddLabel(int noteId, int labelId, int userId);

        Task<string> RemoveLabel(int noteId, int labelId, int userId);

        Task<bool> BulkTrash(int userId, List<int> noteIds);

        Task<IList<NotesModel>> Search(string word, int userId);

        Task<string> Collaborate(int usersId, int noteId, int collaboratorId);
    }
}
