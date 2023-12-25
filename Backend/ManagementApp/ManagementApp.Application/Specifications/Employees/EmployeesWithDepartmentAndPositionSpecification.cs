using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Specifications.Employees
{
    public class EmployeesWithDepartmentAndPositionSpecification : BaseSpecification<Employee>
    {
        public EmployeesWithDepartmentAndPositionSpecification(Guid id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Department);
            AddInclude(x => x.Position);
        }

        public EmployeesWithDepartmentAndPositionSpecification(EmployeeSpecificationParams employeeSpecificationParams) 
            : base(x => 
            (string.IsNullOrEmpty(employeeSpecificationParams.Search) || x.Name.ToLower().Contains(employeeSpecificationParams.Search)) 
            && (!employeeSpecificationParams.DepartmentId.HasValue || x.DepartmentId == employeeSpecificationParams.DepartmentId) 
            && (!employeeSpecificationParams.PositionId.HasValue || x.PositionId == employeeSpecificationParams.PositionId)
            )
        {
            AddInclude(x => x.Department);
            AddInclude(x => x.Position);
            AddOrderBy(x => x.Name);
            ApplyPagination(employeeSpecificationParams.PageSize, (employeeSpecificationParams.CurrentPage - 1) * employeeSpecificationParams.PageSize);

            if (!string.IsNullOrEmpty(employeeSpecificationParams.Sort))
            {
                switch (employeeSpecificationParams.Sort)
                {
                    case "byDepartment":
                        AddOrderBy(x => x.Department.Name);
                        break;
                    case "byPosition":
                        AddOrderBy(x => x.Position.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
    }
}
