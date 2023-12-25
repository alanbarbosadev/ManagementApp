using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployees
{
    public class CreateEmployeesCommandHandler : IRequestHandler<CreateEmployeesCommand, Result<Unit>>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeesCommandHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(CreateEmployeesCommand request, CancellationToken cancellationToken)
        {
            var employees = _mapper.Map<List<Employee>>(request.employeesDtos);

            _employeeRepository.AddRangeAsync(employees);

            var hasChanges = await _employeeRepository.SaveChangesAsync();

            if (hasChanges)
            {
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failed("Failed to insert a new employee");
        }
    }
}
