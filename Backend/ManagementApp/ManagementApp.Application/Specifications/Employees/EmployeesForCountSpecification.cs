using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Specifications.Employees
{
    public class EmployeesForCountSpecification : BaseSpecification<Employee>
    {
        public EmployeesForCountSpecification(EmployeeSpecificationParams employeeSpecificationParams)
            : base(x =>
            (string.IsNullOrEmpty(employeeSpecificationParams.Search) || x.Name.ToLower().Contains(employeeSpecificationParams.Search))
            && (!employeeSpecificationParams.DepartmentId.HasValue || x.DepartmentId == employeeSpecificationParams.DepartmentId)
            && (!employeeSpecificationParams.PositionId.HasValue || x.PositionId == employeeSpecificationParams.PositionId)
            )
        {
            
        }
    }
}
