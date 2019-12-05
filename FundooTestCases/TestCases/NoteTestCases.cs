//----------------------------------------------------
// <copyright file="NoteTestCase.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace FundooTestCases.TestCases
{
    using System;
    using BussinessLayer.Services;
    using CommonLayer.Model;
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
            var model = new NotesModel()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AddReminder = DateTime.Now,
                UserId = 1,
                IsNote = false,
                IsArchive =false,
                IsTrash = false
            };

            //// act          
            var data = business.AddNote(model);

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
            var model = new NotesModel()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AddReminder = DateTime.Now,
                UserId = 1,
                IsNote = false,
                IsArchive = false,
                IsTrash = false
            };

            //// act          
            var data = business.AddNote(model);

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
            var model = new NotesModel()
            {
                Id = 1
            };

            //// act          
            var data = business.DeleteNote(model.Id);

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
            var model = new NotesModel()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AddReminder = DateTime.Now,
                UserId = 1,
                IsNote = false,
                IsArchive = false,
                IsTrash = false
            };

            //// act          
            var data = business.AddNote(model);

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
            var model = new NotesModel()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AddReminder = DateTime.Now,
                UserId = 1,
                IsNote = false,
                IsArchive = false,
                IsTrash = false
            };

            //// act          
            var data = business.AddNote(model);

            ////assert
            Assert.NotNull(data);
        }
    }
}
