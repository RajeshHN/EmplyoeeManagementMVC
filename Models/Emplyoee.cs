using System.ComponentModel.DataAnnotations;

namespace EmplyoeeManagementMVC.Models
{
    public class Emplyoee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public bool IsFullTime { get; set; }
    }
}
