namespace ECommerce.DataAccess.Repository.Category
{
    public interface ICategoryRepository : IRepository<ECommerce.Models.Category>
    {
        void Update(ECommerce.Models.Category category);
    }
}
