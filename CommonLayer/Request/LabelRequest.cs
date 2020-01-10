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
        public string Lable { get; set; }

    }
}
