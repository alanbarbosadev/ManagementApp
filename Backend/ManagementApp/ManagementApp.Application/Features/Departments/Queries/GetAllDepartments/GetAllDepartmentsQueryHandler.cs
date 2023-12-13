using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Shared.Dtos.Departments;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, Result<IReadOnlyList<DepartmentDto>>>
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<DepartmentDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return Result<IReadOnlyList<DepartmentDto>>.Success(_mapper.Map<IReadOnlyList<DepartmentDto>>(await _departmentRepository.GetAllAsync()));
        }
    }
}
