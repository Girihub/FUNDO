using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class CollaborateResponse
    {
        public int NoteId { get; set; }

        public int CollaboratedWithId { get; set; }

        public string CollaboratedWithEmail { get; set; }

        public string CollaboratedWithImage { get; set; }
    }
}
