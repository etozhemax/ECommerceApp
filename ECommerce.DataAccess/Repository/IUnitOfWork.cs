using ECommerce.Data;
using ECommerce.DataAccess.Repository.Category;
using ECommerce.DataAccess.Repository.Company;
using ECommerce.DataAccess.Repository.OrderDetails;
using ECommerce.DataAccess.Repository.OrderHeader;
using ECommerce.DataAccess.Repository.OrderInfo;
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
        IOrderHeaderRepository OrderHeaderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderInfoRepository OrderInfoRepository { get; }

		Task SaveAsync();
    }
}
