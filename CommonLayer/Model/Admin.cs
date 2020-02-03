namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        ////Set the length of field by regular expression
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "FirstName should contain atleast 2 or more characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        ////Set the length of field by regular expression
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "LastName should contain atleast 2 or more characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        ////Validate and set the length of Mobile Number by regular expression
        [RegularExpression("^([789][0-9]{9})$", ErrorMessage = "Please enter 10 digit mobile number")]
        public string MobileNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^([a-zA-Z0-9]{4,8})$", ErrorMessage = "Password should be of 4 to 8 letters")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
