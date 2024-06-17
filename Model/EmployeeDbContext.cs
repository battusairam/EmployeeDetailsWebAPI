using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Model
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<EmployeEntities> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        
    }
}
