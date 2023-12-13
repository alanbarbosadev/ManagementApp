using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Employees;
using ManagementApp.Application.Specifications.Employees;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Queries.GetAllEmployeesWithSpecification
{
    public record GetAllEmployeesWithSpecificationQuery(EmployeeSpecificationParams specificationParams) : IRequest<Result<Pagination<EmployeeDto>>>;
}
