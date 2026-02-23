using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Data;
using StockManagementSystem.Interfaces;

namespace StockManagementSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _db.ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _db.FindAsync(id);

        public async Task InsertAsync(T entity)
            => await _db.AddAsync(entity);

        public void Update(T entity)
            => _db.Update(entity);

        public void Delete(T entity)
            => _db.Remove(entity);
    }
}
