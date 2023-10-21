namespace PaginationWithActionFilter.Models
{
    public class FilterModel
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
        public string Logic { get; set; }
        public List<FilterModel> Filters { get; set; }
    }
}
