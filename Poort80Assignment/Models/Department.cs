using Microsoft.EntityFrameworkCore;

namespace Poort80Assignment.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        { }
        public DbSet<Department> CatalogItems { get; set; }
    }
}
