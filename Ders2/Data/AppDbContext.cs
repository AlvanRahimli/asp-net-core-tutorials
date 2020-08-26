using Ders2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ders2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithOne(cp => cp.Product);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(cp => cp.Category);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
    }
}
