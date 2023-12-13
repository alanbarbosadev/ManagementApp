using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Employees;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Queries.GetEmployeeByIdWithSpecification
{
    public record GetEmployeeByIdWithSpecificationQuery(Guid Id) : IRequest<Result<EmployeeDto>>;
}
