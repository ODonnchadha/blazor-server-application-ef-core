namespace WiredBrainCoffee.EmployeeManager.Data
{
	using Microsoft.EntityFrameworkCore;
	public class EmployeeManagerDbContext : DbContext
    {
        public EmployeeManagerDbContext (DbContextOptions<EmployeeManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;
	    public DbSet<Department> Department { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(
                new Department {  Id = 1, Name = "IT" }
                );
            builder.Entity<Employee>().Property(e => e.DepartmentId).HasDefaultValue(1);
        }
    }
}
