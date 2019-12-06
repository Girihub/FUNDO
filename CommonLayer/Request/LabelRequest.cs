using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class LabelRequest
    {
        /// <summary>
        /// Gets or sets Lable of user
        /// </summary>
        [Required(ErrorMessage = "Lable required")]
        [RegularExpression("^([a-zA-Z0-9 _]{1,})$", ErrorMessage = "Lable should contain atleast 1 character")]
        public string Lable { get; set; }

    }
}
