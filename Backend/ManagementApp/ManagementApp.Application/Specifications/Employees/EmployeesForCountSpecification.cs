using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Specifications.Employees
{
    public class EmployeesForCountSpecification : BaseSpecification<Employee>
    {
        public EmployeesForCountSpecification(EmployeeSpecificationParams employeeSpecificationParams)
            : base(x =>
            (string.IsNullOrEmpty(employeeSpecificationParams.Sort) || x.Name.ToLower().Contains(employeeSpecificationParams.Sort))
            && (!employeeSpecificationParams.DepartmentId.HasValue || x.DepartmentId == employeeSpecificationParams.DepartmentId)
            && (!employeeSpecificationParams.PositionId.HasValue || x.PositionId == employeeSpecificationParams.PositionId)
            )
        {
            
        }
    }
}
