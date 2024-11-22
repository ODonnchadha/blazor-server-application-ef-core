namespace WiredBrainCoffee.EmployeeManager.Data
{
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
	{
        [Column("EmployeeId")]
        public int Id { get; set; }

		[Required(), StringLength(50)]
        public string? FirstName { get; set; }

		[Required(), StringLength(80)]
		public string? LastName { get; set; }

		[Required()]
		public bool IsDeveloper { get; set; }

		[Required(ErrorMessage = "The Department is required.")]
		public int? DepartmentId { get; set; }

		public Department? Department { get; set; }
	}
}
