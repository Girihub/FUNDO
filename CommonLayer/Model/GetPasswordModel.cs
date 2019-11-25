//----------------------------------------------------
// <copyright file="GetPassword.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System.ComponentModel.DataAnnotations;

    public class GetPasswordModel
    {
        /// <summary>
        /// Gets or sets Email of user 
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
