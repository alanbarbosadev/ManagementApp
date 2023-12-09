using ManagementApp.Domain.Enums;

namespace ManagementApp.Domain.Models
{
    public class Activity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityStatus Status { get; set; }
        public List<Employee> Employees { get; set; } = new();
    }
}
