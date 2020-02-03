using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class VotingRequest
    {
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

        [Required(ErrorMessage = "Candidate Id is required")]
        ////Validate and set the length of Candidate Id by regular expression
        [RegularExpression("^([0-9]{1,})$", ErrorMessage = "Please enter digit number")]
        public int CandidateId { get; set; }
    }
}
