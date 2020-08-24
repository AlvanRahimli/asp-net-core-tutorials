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

        }

        public DbSet<Product> Products { get; set; }
    }
}
