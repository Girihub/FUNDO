﻿//----------------------------------------------------
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
            var model = new NoteRequest()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                AddReminder = DateTime.Now,
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
            int id = 1;

            //// act          
            IList<NotesModel> data = business.GetNote(id);

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
            var model = new NoteRequest()
            {
                Title = "title",
                Description = "description",
                Image = "image",
                Color = "color",
                IsPin = true,
                AddReminder = DateTime.Now,
                IsNote = false,
                IsArchive = false,
                IsTrash = false
            };

            //// act          
            IList<NotesModel> data = business.GetNotes(1);

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
    }
}
