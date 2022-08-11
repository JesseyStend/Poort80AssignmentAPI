using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poort80Assignment.Models
{
    public class Employee : EmployeeIn
    {
        [Key]
        public int Id { get; set; }
    }
}
