using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class NoteResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Color { get; set; }

        public bool IsPin { get; set; }

        public DateTime? AddReminder { get; set; }

        public int UserId { get; set; }

        public bool IsNote { get; set; }

        public bool IsArchive { get; set; }

        public bool IsTrash { get; set; }

        public List<LabelModel> labelModels { get; set; }

        public List<CollaborateResponse> collaborateResponses { get; set; }
    }
}
