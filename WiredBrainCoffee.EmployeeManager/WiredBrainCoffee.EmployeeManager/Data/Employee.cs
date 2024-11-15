namespace WiredBrainCoffee.EmployeeManager.Data
{
	using System.ComponentModel.DataAnnotations;
	public class Employee
	{
        public int Id { get; set; }

		[Required(), StringLength(50)]
        public string? FirstName { get; set; }

		[Required(), StringLength(80)]
		public string? LastName { get; set; }

		[Required()]
		public bool IsDeveloper { get; set; }
	}
}
