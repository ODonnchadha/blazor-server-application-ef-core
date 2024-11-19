namespace WiredBrainCoffee.EmployeeManager.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Department
    {
        [Column("DepartmentId")]
        public int Id { get; set; }
        [Required(), StringLength(60)]
        public string? Name { get; set; }
        public ICollection<Employee> Employees { get; } = [];
    }
}
