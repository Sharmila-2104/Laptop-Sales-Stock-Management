using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Models;

namespace StockManagementSystem.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
