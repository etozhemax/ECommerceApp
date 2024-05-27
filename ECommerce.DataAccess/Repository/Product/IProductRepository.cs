namespace ECommerce.DataAccess.Repository.Product
{
    public interface IProductRepository : IRepository<ECommerce.Models.Product>
    {
        public void Update(ECommerce.Models.Product product);
    }
}
