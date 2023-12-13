namespace ManagementApp.Application.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int currentPage, int pageSize, int count, IReadOnlyList<T> data)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
