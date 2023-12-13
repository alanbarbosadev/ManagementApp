using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Unit>>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.employeeDto);

            _employeeRepository.AddAsync(employee);

            var hasChanges = await _employeeRepository.SaveChangesAsync();

            if (hasChanges)
            {
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failed("Failed to insert a new employee");
        }
    }
}
