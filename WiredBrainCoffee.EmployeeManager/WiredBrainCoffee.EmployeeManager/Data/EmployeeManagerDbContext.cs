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
    }
}
