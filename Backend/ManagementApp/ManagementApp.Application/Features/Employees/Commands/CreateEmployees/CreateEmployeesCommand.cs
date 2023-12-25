using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Employees;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployees
{
    public record CreateEmployeesCommand(List<CreateEmployeeDto> employeesDtos) : IRequest<Result<Unit>>;
}
