using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result<Unit>>
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request.departmentDto);

            _departmentRepository.AddAsync(department);

            var hasChanges = await _departmentRepository.SaveChangesAsync();

            if (await _departmentRepository.SaveChangesAsync())
            {
                return Result<Unit>.Success(Unit.Value);
            }
                
            return Result<Unit>.Failed("Failed to insert a new department!");
        }
    }
}
