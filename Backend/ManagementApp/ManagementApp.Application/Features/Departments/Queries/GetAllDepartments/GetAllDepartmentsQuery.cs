using ManagementApp.Application.Shared.Dtos;
using MediatR;

namespace ManagementApp.Application.Features.Departments.Queries.GetAllDepartments
{
    public record GetAllDepartmentsQuery : IRequest<IReadOnlyList<DepartmentDto>>;
}
