using ECommerce.Data;
using ECommerce.DataAccess.Repository.Category;
using ECommerce.DataAccess.Repository.Company;
using ECommerce.DataAccess.Repository.Product;
using ECommerce.DataAccess.Repository.ShoppingCartItem;

namespace ECommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _dbContext;

        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public IShoppingCartItemRepository ShoppingCartItemRepository { get; }

        public UnitOfWork(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;

            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            CompanyRepository = new CompanyRepository(_dbContext);
            ShoppingCartItemRepository = new ShoppingCartItemRepository(_dbContext);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
