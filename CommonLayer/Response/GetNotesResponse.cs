using CommonLayer.Model;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class GetNotesResponse
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

        public List<LabelModel> labelRequests { get; set; }

        public List<CollaborateModel> collaborates { get; set; }

    }
}
