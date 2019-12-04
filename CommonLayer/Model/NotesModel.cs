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
        /// <summary>
        /// Gets or sets id of user
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Title of user
        /// </summary>
        [Required(ErrorMessage = "Title required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Title should contain atleast 1 character")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Description of user
        /// </summary>
        [Required(ErrorMessage = "Description required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Description should contain atleast 1 character")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Image of user
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Color of user
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets IsPin of user
        /// </summary>
        public bool IsPin { get; set; }

        /// <summary>
        /// Gets or sets CreatedDate of user
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets ModifiedDate of user
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets Reminder of user
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// Gets or sets NotesType of user
        /// </summary>
        public NoteOfType NotesType { get; set; }

        /// <summary>
        /// Gets or sets UserId of user
        /// </summary>
        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
    }
}
