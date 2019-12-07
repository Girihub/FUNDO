﻿//----------------------------------------------------
// <copyright file="INotesBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using CommonLayer.Model;
using CommonLayer.Request;
using Microsoft.AspNetCore.Http;
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

        Task<string> Archive(int Id, int UserId);

        IList<NotesModel> GetAllArchives(int UserId);

        Task<string> Trash(int Id, int UserId);

        IList<NotesModel> GetAllTrashed(int UserId);

        Task<string> Pin(int Id, int UserId);

        IList<NotesModel> GetAllPinned(int UserId);

        Task<string> AddImage(IFormFile formFile, int Id, int UserId);
    }
}
