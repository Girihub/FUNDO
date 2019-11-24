//----------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Model
{
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets Email of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^([a-z0-9](.?[a-z0-9]){4,}@g(oogle)?mail.com)$", ErrorMessage = "Enter valid gmail. eg. giri.123@gmail.com")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets OldPassword of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password should be of 4 to 8 letters having atleast 1 upper case letter, 1 lower case letter, 1 digit and 1 _")]
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets NewPassword of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password should be of 4 to 8 letters having atleast 1 upper case letter, 1 lower case letter, 1 digit and 1 _")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Confirm new password
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
