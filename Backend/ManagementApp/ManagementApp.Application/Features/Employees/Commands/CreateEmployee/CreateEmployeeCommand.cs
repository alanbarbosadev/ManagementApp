using MediatR;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(string Name, decimal Salary, DateTime Birthday, Guid DepartmentId, Guid PositionId) : IRequest<Unit>;
}
