namespace ECommerce.Models.ViewModels
{
    public class CategoryPageViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}
