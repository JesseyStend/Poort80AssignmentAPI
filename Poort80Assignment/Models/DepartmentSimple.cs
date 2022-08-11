using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poort80Assignment.Models
{
    public class DepartmentSimple : DepartmentIn
    {
        [Key]
        public int Id { get; set; }
    }
}
