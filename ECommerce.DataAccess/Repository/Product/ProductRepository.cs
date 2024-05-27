using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.Product
{
    public class ProductRepository : Repository<ECommerce.Models.Product>, IProductRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(ECommerce.Models.Product product)
        {
            _dbContext.Update(product);
        }
    }
}
