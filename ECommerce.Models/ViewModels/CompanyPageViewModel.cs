namespace ECommerce.Models.ViewModels
{
    public class CompanyPageViewModel
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}
