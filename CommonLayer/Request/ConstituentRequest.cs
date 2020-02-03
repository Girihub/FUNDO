using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class ConstituentRequest
    {
        [Required(ErrorMessage = "ConstituencyName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "ConstituencyName should contain atleast 1 or more characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "State should contain atleast 1 or more characters")]
        public string State { get; set; }
    }
}
