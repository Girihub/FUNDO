//----------------------------------------------------
// <copyright file="CollaborateModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CollaborateModel class
    /// </summary>
    public class CollaborateModel
    {
        /// <summary>
        /// Gets or sets Id as primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Collaborator Id
        /// </summary>
        [Required]
        [RegularExpression("^([0-9])$", ErrorMessage = "Enter valid integer")]
        [ForeignKey("RegistrationModel")]
        public int CollaboratedBy { get; set; }

        /// <summary>
        /// Gets or sets User Id
        /// </summary>
        [Required]
        [ForeignKey("RegistrationModel")]
        [RegularExpression("^([0-9])$", ErrorMessage = "Enter valid integer")]
        public int CollaboratedWith { get; set; }

        /// <summary>
        /// Gets or sets Note Id
        /// </summary>
        [Required]
        [RegularExpression("^([0-9])$", ErrorMessage = "Enter valid integer")]
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets CreatedDate of user
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets ModifiedDate of user
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
