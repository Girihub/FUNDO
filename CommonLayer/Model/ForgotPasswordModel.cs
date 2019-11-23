//----------------------------------------------------
// <copyright file="ForgotPasswordModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ForgotPassword Model class
    /// </summary>
    public class ForgotPasswordModel
    {
        /// <summary>
        /// Gets or sets Email of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^([a-z0-9](.?[a-z0-9]){4,}@g(oogle)?mail.com)$", ErrorMessage = "Enter valid gmail. eg. giri.123@gmail.com")]
        public string Email { get; set; }
    }
}
