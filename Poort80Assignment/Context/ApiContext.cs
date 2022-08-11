using Microsoft.EntityFrameworkCore;
using Poort80Assignment.Models;

namespace Poort80Assignment.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Navigation(d => d.employees).AutoInclude();

            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = 1, Name = "Jessey Stend", DepartmentId = 1},
                    new Employee { Id = 2, Name = "Dennis Jongbloed", DepartmentId = 1 },
                    new Employee { Id = 3, Name = "Sary t'Lam", DepartmentId = 2 }
                );

            modelBuilder.Entity<Department>().HasData(
                    new Department { Id = 1, Name = "Development", Description = "Development department" },
                    new Department { Id = 2, Name = "Inplan", Description = "Inplan department" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
