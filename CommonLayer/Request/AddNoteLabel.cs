using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Request
{
    public class AddNoteLabel
    {
        public int noteId { get; set; }

        public int labelId { get; set; }
    }
}
