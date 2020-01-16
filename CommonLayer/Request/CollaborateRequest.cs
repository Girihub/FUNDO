
using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Request
{
    public class CollaborateRequest
    {
        [Required]
        public int CollaboratedWith { get; set; }

        [Required]
        public int NoteId { get; set; }
    }
}
