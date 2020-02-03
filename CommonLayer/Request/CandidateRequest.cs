using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Request
{
    public class CandidateRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "FirstName should contain atleast 1 or more characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "LastName should contain atleast 1 or more characters")]
        public string LastName { get; set; }

        [ForeignKey("Party")]
        public int PartyId { get; set; }

        [ForeignKey("Constituency")]
        public int ConstituencyId { get; set; }
    }
}
