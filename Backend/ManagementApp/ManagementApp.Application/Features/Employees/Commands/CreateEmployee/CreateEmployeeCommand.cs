using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Employees;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(CreateEmployeeDto employeeDto) : IRequest<Result<Unit>>;
}
