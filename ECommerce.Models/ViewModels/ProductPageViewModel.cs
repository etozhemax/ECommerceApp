namespace ECommerce.Models.ViewModels
{
    public class ProductPageViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}
