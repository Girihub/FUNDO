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

        public string Lable { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Id")]
        public RegistrationModel UserId { get; set; }
    }
}
