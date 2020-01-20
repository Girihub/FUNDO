//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        Task<NotesModel> AddNote(NoteRequest noteRequest, int userId);

        Task<bool> DeleteNote(int id, int userId);

        IList<NotesModel> GetNotes(int userId);

        Task<NotesModel> UpdateNote(int id, NoteUpdate noteUpdate, int userId);

        NotesModel GetNote(int id, int userId);

        Task<string> Archive(int id, int userId);

        IList<NotesModel> GetAllArchives(int userId);

        Task<string> Trash(int Id, int userId);

        IList<NotesModel> GetAllTrashed(int userId);

        Task<string> Pin(int id, int userId);

        IList<NotesModel> GetAllPinned(int UserId);

        Task<string> AddImage(IFormFile formFile, int id, int userId);

        Task<string> AddImageToCreateNote(IFormFile formFile, int userId);

        Task<string> AddReminder(ReminderRequest dateTime, int id, int userId);

        IList<NotesModel> ReminderedNotes(int userId);

        Task<string> ChangeColor(int id, string color, int userId);

        Task<bool> AddLabel(int noteId, int labelId, int userId);

        Task<bool> RemoveLabel(int noteId, int labelId, int userId);

        Task<bool> BulkTrash(int userId, List<int> noteIds);

        Task<IList<NotesModel>> Search(string word, int userId);

        Task<bool> Collaborate(int usersId, int noteId, int collaboratorId);

        Task<bool> DeleteCollaborator(int usersId, int noteId, int collaboratorId);

        IList<CollaborateModel> GetCollaborate(int collaboratorId);

        IList<CollaborateModel> GetCollaborateById(int collaboratorId, int noteId);

        IList<NoteLabelModel> GetNotesLabel(int userId);

        IList<NoteLabelModel> GetNotesLabelById(int userId, int noteId);        

        NoteResponse NoteResponse(int userId, int noteId);

        IList<NoteResponse> NoteResponse(int userId);
    }
}
