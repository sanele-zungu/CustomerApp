using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models
{
	public class Customer
	{
		public Customer()
		{

		}

		[Key]
		public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string? CustomerName { get; set; }
        [Required(ErrorMessage = "Customer Address is required")]
        public string? CustomerAddress { get; set; }
		public string? CustomerTelephone { get; set; }
		public string? ContactPersonName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address entered")]
        public string? ContactPersonEmailAddress { get; set; }
		public string? VATNumber { get; set; }
	}
}
