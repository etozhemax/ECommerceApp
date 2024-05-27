namespace ECommerce.Core.Pagination
{
    public class PagedList<T> where T : class
    {
        public IEnumerable<T> PagedItems { get; set; }
        public int TotalSize { get; set; }
        public int TotalPages { get; set; }

        public PagedList(IQueryable<T> list, PagedOptions options) 
        {
            PagedItems = list.Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize).ToList();
            TotalSize = list.Count();
            TotalPages = (int)Math.Ceiling(TotalSize / (double)options.PageSize);
        }
    }
}
