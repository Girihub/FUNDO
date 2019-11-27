//----------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static CommonLayer.Model.NoteEnumType;

    public class NotesModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Title should contain atleast 1 character")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Description should contain atleast 1 character")]
        public string Description { get; set; }

        public string Image { get; set; }        

        public string Color { get; set; }

        public bool IsPin { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Reminder { get; set; }

        public NoteOfType NotesType { get; set; }

        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
    }
}
