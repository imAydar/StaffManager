using Microsoft.EntityFrameworkCore;
using StaffManager.Data.Entities;

namespace StaffManager.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>().HasMany(x => x.Employees).WithOne(x => x.Department);
            builder.Entity<Department>().Property(x => x.Name).IsRequired();

            builder.Entity<Employee>().Property(x => x.DepartmentId).IsRequired();
            builder.Entity<Employee>().Property(x => x.Name).IsRequired();
            builder.Entity<Employee>().Property(x => x.Salary).IsRequired();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}