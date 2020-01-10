using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class NoteRequest
    {        
        /// <summary>
        /// Gets or sets Title of user
        /// </summary>        
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Description of user
        /// </summary>        
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Image of user
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Color of user
        /// </summary>        
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Reminder of user
        /// </summary> 
        public DateTime? Reminder { get; set; }

        /// <summary>
        /// Gets or sets IsPin of user
        /// </summary>
        public bool IsPin { get; set; }

        /// <summary>
        /// Gets or sets IsNote of user
        /// </summary>
        public bool IsNote { get; set; }

        /// <summary>
        /// Gets or sets IsArchive of user
        /// </summary>
        public bool IsArchive { get; set; }

        /// <summary>
        /// Gets or sets IsTrash of user
        /// </summary>
        public bool IsTrash { get; set; }
    }
}
