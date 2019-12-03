
namespace FundooTestCases.TestCases
{
    using BussinessLayer.Services;
    using CommonLayer.Model;
    using Moq;
    using RepositoryLayer.Interfaces;
    using System;
    using Xunit;

    public class NoteTestCases
    {
        public class NoteTestCase
        {
            /// <summary>
            /// test case for AddNotes.
            /// </summary>
            [Fact]
            public void AddNotes()
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
                    Reminder = "reminder",
                    NotesType = 0
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
                    Reminder = "reminder",
                    NotesType = 0
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
                    Title = "title",
                    Description = "description",
                    Image = "image",
                    Color = "color",
                    IsPin = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Reminder = "reminder",
                    NotesType = 0
                };
            }
        }
    }
}

