using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Shared.Dtos.Employees;
using ManagementApp.Application.Specifications.Employees;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Queries.GetAllEmployeesWithSpecification
{
    public class GetAllEmployeesWithSpecificationQueryHandler : IRequestHandler<GetAllEmployeesWithSpecificationQuery, Result<Pagination<EmployeeDto>>>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesWithSpecificationQueryHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Pagination<EmployeeDto>>> Handle(GetAllEmployeesWithSpecificationQuery request, CancellationToken cancellationToken)
        {
            var specification = new EmployeesWithDepartmentAndPositionSpecification(request.specificationParams);

            var specificationForCount = new EmployeesForCountSpecification(request.specificationParams);

            var employees = _mapper.Map<IReadOnlyList<EmployeeDto>>(await _employeeRepository.GetAllWithSpecificationAsync(specification));

            var count = await _employeeRepository.CountAsync(specificationForCount);

            return Result<Pagination<EmployeeDto>>
                .Success(new Pagination<EmployeeDto>(request.specificationParams.CurrentPage, request.specificationParams.PageSize, count, employees));
        }
    }
}
