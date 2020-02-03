namespace CommonLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Constituency
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ConstituencyName is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "ConstituencyName should contain atleast 1 or more characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State is required")]
        [RegularExpression("^([a-zA-Z]{1,})$", ErrorMessage = "State should contain atleast 1 or more characters")]
        public string State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
