using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
	public class OrderInfo
	{
        public int Id { get; set; }

        [Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string StreetAddress { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string PostalCode { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
