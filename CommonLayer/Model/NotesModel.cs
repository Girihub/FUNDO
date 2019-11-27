//----------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using CommonLayer.Enum;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NotesModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }        

        public string Color { get; set; }

        public string IsPin { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Reminder { get; set; }

        public NoteEnumType NoteType { get; set; }

        [ForeignKey("Id")]
        public RegistrationModel UserId { get; set; }
    }
}
