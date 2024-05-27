﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        public string EcommerceApplicationUserId { get; set; }

        [ForeignKey("EcommerceApplicationUserId")]
        [ValidateNever]
        public EcommerceApplicationUser EcommerceApplicationUser { get; set; }

        [Range(1, 1000, ErrorMessage = "Please, enter the value from 1 to 1000" )]
        public int Count { get; set; }
    }
}
