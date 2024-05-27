using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.Category
{
    public class CategoryRepository : Repository<ECommerce.Models.Category>, ICategoryRepository
    {
        private readonly ECommerceDbContext dbContext;

        public CategoryRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(ECommerce.Models.Category category)
        {
            dbContext.Update(category);
        }
    }
}
