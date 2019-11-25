//----------------------------------------------------
// <copyright file="ResetForgetPasswordModel.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ResetForgetPasswordModel as a class
    /// </summary>
    public class ResetForgetPasswordModel
    {
        /// <summary>
        /// Gets or sets token of user 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets NewPassword of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password should be of 4 to 8 letters having atleast 1 upper case letter, 1 lower case letter, 1 digit and 1 _")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets ConfirmPassword of user. Confirm new password
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
