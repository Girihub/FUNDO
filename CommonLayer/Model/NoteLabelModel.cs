
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommonLayer.Model
{
    public class NoteLabelModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        [ForeignKey("LabelModel")]
        public int LabelId { get; set; }

        public bool Delete { get; set; } = false;

        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
    }
}
