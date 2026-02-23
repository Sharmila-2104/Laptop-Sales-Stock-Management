using StockManagementSystem.Data;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Laptop> Laptops { get; }
        public IGenericRepository<Sale> Sales { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Laptops = new GenericRepository<Laptop>(context);
            Sales = new GenericRepository<Sale>(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
