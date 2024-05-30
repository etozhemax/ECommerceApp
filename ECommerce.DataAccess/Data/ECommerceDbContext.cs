using ECommerce.Models;
using ECommerce.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ECommerceDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EcommerceApplicationUser> EcommerceUsers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

		public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Category 2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Category 3", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Company 1" },
                new Company { Id = 2, Name = "Company 2" },
                new Company { Id = 3, Name = "Company 3" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    ImageUrl = string.Empty,
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    Price = 90,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    ImageUrl = string.Empty,
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    Price = 30,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    ImageUrl = string.Empty,
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    Price = 50,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    ImageUrl = string.Empty,
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    Price = 65,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    ImageUrl = string.Empty,
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    Price = 27,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    ImageUrl = string.Empty,
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    Price = 23,
                    CategoryId = 3
                }
            );
        }
    }
}
