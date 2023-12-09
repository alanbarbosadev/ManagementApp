namespace ManagementApp.Application.Specifications.Employees
{
    public class EmployeeSpecificationParams
    {
        private const int MAX_PAGE_SIZE = 50;
        public int CurrentPage { get; set; } = 1;

        private int _pageSize = 5;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value; }
        }

        public Guid? DepartmentId { get; set; }
        public Guid? PositionId { get; set; }
        public string Sort { get; set; }
        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
    }
}
