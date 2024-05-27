using ECommerce.Core.Pagination;

namespace ECommerce.DataAccess.Repository.Company
{
    public interface ICompanyRepository : IRepository<ECommerce.Models.Company>
    {
        public void Update(ECommerce.Models.Company product);
    }
}
