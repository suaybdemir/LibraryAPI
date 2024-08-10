using LibraryAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Employee : AbstractPerson
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = "";
        public float Salary { get; set; }
        public string Department { get; set; } = "";
        public string? Shift { get; set; }
        
    }
}
