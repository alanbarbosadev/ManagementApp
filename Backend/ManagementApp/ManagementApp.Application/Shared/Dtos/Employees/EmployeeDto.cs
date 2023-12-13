namespace ManagementApp.Application.Shared.Dtos.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
