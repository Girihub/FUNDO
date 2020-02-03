using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class PartyRequest
    {
        [Required(ErrorMessage = "PartyName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "PartyName should contain atleast 1 or more characters")]
        public string PartyName { get; set; }
    }
}
