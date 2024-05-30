using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
	public class OrderHeader
	{
		public int Id { get; set; }

		public string EcommerceApplicationUserId { get; set; }

		[ForeignKey("ApplicationUserId")]
		[ValidateNever]
		public EcommerceApplicationUser EcommerceApplicationUser { get; set; }

		public int OrderInfoId { get; set; }

		[ForeignKey("OrderInfoId")]
		[ValidateNever]
		public OrderInfo OrderInfo { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime ShippingDate { get; set; }

		public double OrderTotal { get; set; }

		public string? OrderStatus { get; set; }

		public string? PaymentStatus { get; set; }

		public string? TrackingNumber { get; set; }

		public string? Carrier { get; set; }

		public DateTime PaymentDate { get; set; }

		public DateTime PaymentDueDate { get; set; }

		public string? SessionId { get; set; }

		public string? PaymentIntentId { get; set; }
	}
}
