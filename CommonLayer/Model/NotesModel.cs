//----------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
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
        [Required(ErrorMessage = "Color code required")]
        [RegularExpression("^(#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3}))$", ErrorMessage = "Enter valid 6 letters color code. eg. #0f0f0f")]
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
        public DateTime AddReminder { get; set; }
        
        /// <summary>
        /// Gets or sets UserId of user
        /// </summary>
        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets IsNote of user
        /// </summary>
        public bool IsNote { get; set; }

        /// <summary>
        /// Gets or sets IsArchive of user
        /// </summary>
        public bool IsArchive { get; set; }

        /// <summary>
        /// Gets or sets IsTrash of user
        /// </summary>
        public bool IsTrash { get; set; }
    }
}
