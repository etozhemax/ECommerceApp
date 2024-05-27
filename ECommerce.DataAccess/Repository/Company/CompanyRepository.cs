
using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.Company
{
    public class CompanyRepository : Repository<ECommerce.Models.Company>, ICompanyRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public CompanyRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(ECommerce.Models.Company product)
        {
            _dbContext.Update(product);
        }
    }
}
