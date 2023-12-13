using ManagementApp.Application.Shared.Dtos;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Queries.GetEmployeeByIdWithSpecification
{
    public record GetEmployeeByIdWithSpecificationQuery(Guid Id) : IRequest<EmployeeDto>;
}
