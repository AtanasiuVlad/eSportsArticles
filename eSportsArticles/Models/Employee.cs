using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eSportsArticles.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
		[Display(Name = "First name")]
		[Required(ErrorMessage = "First name is required")]
		public string firstName { get; set; }
		[Display(Name = "Last name")]
		[Required(ErrorMessage = "Last name is required")]
		public string lastName { get; set; }
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }
		[Display(Name = "Phone")]
		[Required(ErrorMessage = "Phone is required")]
		public string Phone { get; set; }
		[Display(Name = "City")]
		[Required(ErrorMessage = "City is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "City must be between 3 and 50 chars")]
		public string City { get; set; }
		[Display(Name = "Position")]
		[Required(ErrorMessage = "Position is required")]
		public string employeePosition { get; set; }
		[Display(Name = "Salary")]
		[Required(ErrorMessage = "Salary is required")]
		public int Salary { get; set; }

        //Store
        public Guid storeId { get; set; }

        [ForeignKey("storeId")]
        public Store Store { get; set; }
    }
}
