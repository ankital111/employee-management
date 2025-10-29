using Microsoft.EntityFrameworkCore;
using employee_management.Models;

namespace employee_management.Data  // ✅ Must match your folder name
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }  // ✅ Must have at least one DbSet
    }
}
