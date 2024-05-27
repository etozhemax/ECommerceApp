using ECommerce.Core.Pagination;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceDbContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public Repository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public PagedList<T> GetAsync(PagedOptions options)
        {
            return new PagedList<T>(_dbSet, options);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, string? properties)
        {
            if (properties != null)
            {
                return await _dbSet.Where(expression).Include(properties).ToListAsync();
            }

            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
