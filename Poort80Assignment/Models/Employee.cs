using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poort80Assignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters, name can only be 100 characters long")]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
