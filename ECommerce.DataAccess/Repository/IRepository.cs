using ECommerce.Core.Pagination;
using System.Linq.Expressions;

namespace ECommerce.DataAccess.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<T?> GetByIdAsync(int id);
        PagedList<T> GetAsync(PagedOptions options);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, string? properties = null);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
