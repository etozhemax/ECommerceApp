namespace ECommerce.Models.ViewModels
{
    public class ShoppingCartItemPageViewModel
    {
        public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
        public double Total { get; set; }
    }
}
