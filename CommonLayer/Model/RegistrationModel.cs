using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Model
{
    public class RegistrationModel
    {
        /// <summary>
        /// Gets or sets Id of user
        /// </summary>        
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets First Name of user
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "FirstName is required")]
        ////Set the length of field by regular expression
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "FirstName should contain atleast 2 or more characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "LastName is required")]
        ////Set the length of field by regular expression
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "LastName should contain atleast 2 or more characters")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Mobile Number of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Mobile no. is required")]
        ////Validate and set the length of Mobile Number by regular expression
        [RegularExpression("^([789][0-9]{9})$", ErrorMessage = "Please enter 10 digit mobile no. starts from 7 or 8 or 9")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets Email of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^([a-z0-9](.?[a-z0-9]){5,}@g(oogle)?mail.com)$", ErrorMessage = "Enter valid gmail. eg. giri.123@gmail.com")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password of user 
        /// </summary>
        /// Set the field compulsory to fill by annotation
        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password should be of 4 to 8 letters having atleast 1 upper case letter, 1 lower case letter, 1 digit and 1 _")]
        public string Password { get; set; }
    }
}
