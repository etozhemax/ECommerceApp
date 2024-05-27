using ECommerce.Data;
using ECommerce.DataAccess.Repository.Category;
using ECommerce.DataAccess.Repository.Company;
using ECommerce.DataAccess.Repository.Product;
using ECommerce.DataAccess.Repository.ShoppingCartItem;

namespace ECommerce.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IShoppingCartItemRepository ShoppingCartItemRepository { get; }

        Task SaveAsync();
    }
}
