//----------------------------------------------------
// <copyright file="NoteTestCase.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace FundooTestCases.TestCases
{
    using System;
    using System.Collections.Generic;
    using BussinessLayer.Services;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Moq;
    using RepositoryLayer.Interfaces;    
    using Xunit;

    /// <summary>
    /// test cases for notes
    /// </summary>
    public class NoteTestCase
    {
        /// <summary>
        /// test case for AddNote.
        /// </summary>
        [Fact]
        public void AddNote()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NoteRequest()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                IsNote = false,
                IsArchive =false,
                IsTrash = false
            };

            //// act          
            var data = business.AddNote(model, 1);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case for UpdateNote.
        /// </summary>
        [Fact]
        public void UpdateNote()
        {            
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NoteUpdate()
            {
                Title = "title",
                Description = "description"
            };

            //// act          
            var data = business.UpdateNote(1, model,1);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case for DeleteNote.
        /// </summary>
        [Fact]
        public void DeleteNote()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                UserId = 1
            };

            //// act          
            var data = business.DeleteNote(model.Id, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test cases for get note by id
        /// </summary>
        [Fact]
        public void GetNote()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            int id = 1;
            int userId = 1;

            //// act          
            IList<NotesModel> data = business.GetNote(id, userId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test cases for get all notes
        /// </summary>
        [Fact]
        public void GetNotes()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            int userId = 1;

            //// act          
            var data = business.GetNotes(userId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to archive note
        /// </summary>
        [Fact]
        public void Archive()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                UserId = 1,
                IsArchive = true
            };

            //// act
            var data = business.Archive(model.Id, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to trash note
        /// </summary>
        [Fact]
        public void Trash()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                UserId = 1,
                IsTrash = true
            };

            //// act
            var data = business.Trash(model.Id, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to pin note
        /// </summary>
        [Fact]
        public void Pin()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                UserId = 1,
                IsPin = true
            };

            //// act
            var data = business.Pin(model.Id, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to add reminder
        /// </summary>
        [Fact]
        public void AddReminder()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                AddReminder = DateTime.Now,
                UserId = 1
            };

            //// act
            var data = business.AddReminder(model.AddReminder, model.Id, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to change color of note
        /// </summary>
        [Fact]
        public void ChangeColor()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var model = new NotesModel()
            {
                Id = 1,
                Color = "#0f0f0f",
                UserId = 1
            };

            //// act
            var data = business.ChangeColor(model.Id, model.Color, model.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to Add Label into note
        /// </summary>
        [Fact]
        public void AddLabel()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var note = new NotesModel()
            {
                Id = 1,
                UserId = 1
            };

            int labelId = 1;

            //// act
            var data = business.AddLabel(note.Id, labelId, note.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to remove label into note
        /// </summary>
        [Fact]
        public void RemoveLabel()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var note = new NotesModel()
            {
                Id = 1,
                UserId = 1
            };

            int labelId = 1;

            //// act
            var data = business.RemoveLabel(note.Id, labelId, note.UserId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to bulk trash the notes
        /// </summary>
        [Fact]
        public void BulkTrash()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            int userId = 1;
            List<int> noteIds = new List<int>();

            //// act
            var data = business.BulkTrash(userId, noteIds);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to search the notes
        /// </summary>
        [Fact]
        public void Search()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            int userId = 1;
            string word = "note to be searched";

            //// act
            var data = business.Search(word, userId);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case to collaborate with other users
        /// </summary>
        [Fact]
        public void Collaborate()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<INotesRL>();
            var business = new NotesBL(repository.Object);

            ////arrange
            var note = new NotesModel()
            {
                Id = 1,
                UserId = 1
            };

            int colaberateWith = 2;

            //// act
            var data = business.Collaborate(colaberateWith, note.Id, note.UserId);

            ////assert
            Assert.NotNull(data);
        }
    }
}
