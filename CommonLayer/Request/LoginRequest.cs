using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password?")]
        [RegularExpression("^([a-zA-Z0-9]{4,8})$", ErrorMessage = "Password should be of 4 to 8 letters")]
        public string Password { get; set; }
    }
}
