namespace ManagementApp.Domain.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HiredAt { get; set; } = DateTime.Now;
        public List<Activity> Activities { get; set; } = new();
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public Position Position { get; set; }
        public Guid PositionId { get; set; }
    }
}
