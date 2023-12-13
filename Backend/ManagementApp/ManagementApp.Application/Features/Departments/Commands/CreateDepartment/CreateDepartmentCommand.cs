using MediatR;

namespace ManagementApp.Application.Features.Departments.Commands.CreateDepartment
{
    public record CreateDepartmentCommand(string Name) : IRequest<Unit>;
}
