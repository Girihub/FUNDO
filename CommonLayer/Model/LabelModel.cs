//----------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LabelModel
    {
        /// <summary>
        /// Gets or sets id of user
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Lable of user
        /// </summary>
        [Required(ErrorMessage = "Lable required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Lable should contain atleast 1 character")]
        public string Lable { get; set; }

        /// <summary>
        /// Gets or sets CreatedDate of user
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets ModifiedDate of user
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets UserId of user
        /// </summary>
        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
    }
}
