using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Laptop> Laptops { get; }
        IGenericRepository<Sale> Sales { get; }

        Task SaveAsync();
    }
}
