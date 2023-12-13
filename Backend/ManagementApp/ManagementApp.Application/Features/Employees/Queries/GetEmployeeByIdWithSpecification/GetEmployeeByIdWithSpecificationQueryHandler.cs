using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Shared.Dtos.Employees;
using ManagementApp.Application.Specifications.Employees;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Queries.GetEmployeeByIdWithSpecification
{
    public class GetEmployeeByIdWithSpecificationQueryHandler : IRequestHandler<GetEmployeeByIdWithSpecificationQuery, Result<EmployeeDto>>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdWithSpecificationQueryHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdWithSpecificationQuery request, CancellationToken cancellationToken)
        {
            var specification = new EmployeesWithDepartmentAndPositionSpecification(request.Id);

            var employee = await _employeeRepository.GetByIdWithSpecificationAsync(specification);

            return Result<EmployeeDto>.Success(_mapper.Map<EmployeeDto>(employee));
        }
    }
}
