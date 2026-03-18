using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrbanPalate.Models;
using UrbanPalate.ViewModels;

namespace UrbanPalate.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            modelBuilder.Entity<Category>().HasData(
             new Category { CategoryId = 1, Name = "Vegetarian" },
             new Category { CategoryId = 2, Name = "Non-Vegetarian" },
             new Category { CategoryId = 3, Name = "Breads" },
             new Category { CategoryId = 4, Name = "Main Courses" },
             new Category { CategoryId = 5, Name = "Biryani " },
             new Category { CategoryId = 6, Name = "Regional Special" },
             new Category { CategoryId = 7, Name = "Coffee" },
             new Category { CategoryId = 8, Name = "Starters" },
             new Category { CategoryId = 9, Name = "Appetizers " },
             new Category { CategoryId = 10, Name = "Tandoori & Grilled Items" },
             new Category { CategoryId = 11, Name = "Street Food " },
             new Category { CategoryId = 12, Name = "Desserts and Sweets" },
             new Category { CategoryId = 13, Name = "Beverages" },
             new Category { CategoryId = 14, Name = "Accompaniments & Condiments" },
             new Category { CategoryId = 15, Name = "Multi-Course Platters" },
             new Category { CategoryId = 16, Name = "South Indian Specialties" }
           );

            modelBuilder.Entity<Ingredient>().HasData(
              new Ingredient { IngredientId = 1, Name = "Vegetables" },
              new Ingredient { IngredientId = 2, Name = "Breads" },
              new Ingredient { IngredientId = 3, Name = "Dairy & Cheese" },
              new Ingredient { IngredientId = 4, Name = "Fruits" },
              new Ingredient { IngredientId = 5, Name = "Rice" },
              new Ingredient { IngredientId = 6, Name = "Chilies" },
              new Ingredient { IngredientId = 7, Name = "Turmeric" },
              new Ingredient { IngredientId = 8, Name = "Cumin" },
              new Ingredient { IngredientId = 9, Name = "Coriander" },
              new Ingredient { IngredientId = 10, Name = "Mint" },
              new Ingredient { IngredientId = 11, Name = "Methi" },
              new Ingredient { IngredientId = 12, Name = "Garam Masala" }
          );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ProductId = 1,
                    Name = "Chicken Tikka",
                    Description = "Fresh lemon wedge and mint or aromatic flavor",
                    Price = 150.0m,
                    Stock = 100,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Paneer Butter Masala",
                    Description = "A delicious Achari panner tikka",
                    Price = 215.60m,
                    Stock = 19,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Pakora",
                    Description = "mixed Vegetable Pakoras include paneer, potato, Gobi and chiken",
                    Price = 3.99m,
                    Stock = 90,
                    CategoryId = 10
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Fried Rice",
                    Description = "Most delicious fried rice for all",
                    Price = 3.99m,
                    Stock = 90,
                    CategoryId = 4
                }
                );

            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 3 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },
                new ProductIngredient { ProductId = 1, IngredientId = 7 },
                new ProductIngredient { ProductId = 2, IngredientId = 1 },
                new ProductIngredient { ProductId = 2, IngredientId = 3 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 7 },
                new ProductIngredient { ProductId = 3, IngredientId = 1 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 4, IngredientId = 1 },
                new ProductIngredient { ProductId = 4, IngredientId = 5 },
                new ProductIngredient { ProductId = 4, IngredientId = 7 }
            );
        }
    }
}
