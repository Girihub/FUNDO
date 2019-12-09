

namespace CommonLayer.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NoteUpdate
    {
        /// <summary>
        /// Gets or sets Title of user
        /// </summary>        
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Description of user
        /// </summary>
        public string Description { get; set; }

    }
}
