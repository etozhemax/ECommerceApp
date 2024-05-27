namespace ECommerce.DataAccess.Repository.ShoppingCartItem
{
    public interface IShoppingCartItemRepository : IRepository<Models.ShoppingCartItem>
    {
        public void Update(ECommerce.Models.ShoppingCartItem shoppingCartItem);
    }
}
