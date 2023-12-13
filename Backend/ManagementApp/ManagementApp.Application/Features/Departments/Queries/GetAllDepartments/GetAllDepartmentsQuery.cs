using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Departments;
using MediatR;

namespace ManagementApp.Application.Features.Departments.Queries.GetAllDepartments
{
    public record GetAllDepartmentsQuery : IRequest<Result<IReadOnlyList<DepartmentDto>>>;
}
