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
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lable required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Lable should contain atleast 1 character")]
        public string Lable { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
    }
}
