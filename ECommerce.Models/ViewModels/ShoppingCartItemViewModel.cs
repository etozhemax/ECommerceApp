namespace ECommerce.Models.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
