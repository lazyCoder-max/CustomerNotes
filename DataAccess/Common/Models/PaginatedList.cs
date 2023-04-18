namespace DataAccess.Common.Models
{
    public class PaginatedList<T>
    {
        public IReadOnlyCollection<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public PaginatedList(IReadOnlyCollection<T> item, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalCount = count;
            TotalPages  = (int)Math.Ceiling(count/(double)pageSize);
            Items = item;
        }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

    }
}
