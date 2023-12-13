using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Shared.Dtos.Employees
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
    }
}
