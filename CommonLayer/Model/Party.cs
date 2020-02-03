namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Party
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PartyName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "PartyName should contain atleast 1 or more characters")]
        public string PartyName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
