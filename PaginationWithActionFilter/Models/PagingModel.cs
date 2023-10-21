namespace PaginationWithActionFilter.Models
{
    public class PagingModel
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public List<FilterModel> Filters { get; set; }

        public string Logic { get; set; }
    }
}
