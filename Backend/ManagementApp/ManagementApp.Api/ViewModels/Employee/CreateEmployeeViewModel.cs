namespace ManagementApp.Api.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
    }
}
