using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Departments;
using MediatR;

namespace ManagementApp.Application.Features.Departments.Commands.CreateDepartment
{
    public record CreateDepartmentCommand(CreateDepartmentDto departmentDto) : IRequest<Result<Unit>>;
}
