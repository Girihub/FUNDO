

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

        /// <summary>
        /// Gets or sets Image of user
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Color of user
        /// </summary>
        [RegularExpression("^(#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3}))$", ErrorMessage = "Enter valid 6 letters color code. eg. #0f0f0f")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets IsPin of user
        /// </summary>
        public bool IsPin { get; set; }

        /// <summary>
        /// Gets or sets Reminder of user
        /// </summary>
        public DateTime AddReminder { get; set; }

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
