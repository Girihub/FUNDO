using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                this.appDbContext.Notes.Add(notesModel);
                var result = await this.appDbContext.SaveChangesAsync();
                return "Note added";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> DeleteNote(int id)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id).FirstOrDefault();

                if(notes != null)
                {
                    this.appDbContext.Notes.Remove(notes);
                    var result = await this.appDbContext.SaveChangesAsync();
                    return "Note deleted";
                }
                return "Note not present in the table";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<NotesModel> GetNote(int id)
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();
                var note = this.appDbContext.Notes.Where(g => g.Id == id).FirstOrDefault();
                    notes.Add(note);
                    return notes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<NotesModel> GetNotes()
        {
            try
            {
                List<NotesModel> notes = new List<NotesModel>();

                foreach (var line in appDbContext.Notes)
                {
                    notes.Add(line);
                }
                return notes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public string UpdateNote(int id, NotesModel notesModel)
        {
            try
            {
                var notes = this.appDbContext.Notes.Where(g => g.Id == id).FirstOrDefault();
                
                if (notes != null)
                {
                    notes.Title = notesModel.Title;
                    notes.Description = notesModel.Description;
                    notes.Image = notesModel.Image;
                    notes.Color = notesModel.Color;
                    notes.IsPin = notesModel.IsPin;
                    notes.CreatedDate = notesModel.CreatedDate;
                    notes.ModifiedDate = notesModel.ModifiedDate;
                    notes.Reminder = notesModel.Reminder;
                    notes.NotesType = notesModel.NotesType;
                    appDbContext.Entry(notes).State = EntityState.Modified;
                    this.appDbContext.SaveChanges();
                    return "Updated";
                }

                return "Enter valid Id";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
