using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.ShoppingCartItem
{
    public class ShoppingCartItemRepository : Repository<Models.ShoppingCartItem>, IShoppingCartItemRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public ShoppingCartItemRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Models.ShoppingCartItem shoppingCartItem)
        {
            _dbContext.Update(shoppingCartItem);
        }
    }
}
