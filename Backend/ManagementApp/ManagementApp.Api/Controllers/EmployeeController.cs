using AutoMapper;
using ManagementApp.Api.Helpers;
using ManagementApp.Api.ViewModels.Employee;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Services;
using ManagementApp.Application.Specifications.Employees;
using ManagementApp.Domain.Exceptions;
using ManagementApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EmployeeController(IRepository<Employee> employeeRepository, IUserService userService, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Pagination<EmployeeViewModel>>> GetAllEmployees([FromQuery] EmployeeSpecificationParams employeeSpecificationParams)
        {
            var specification = new EmployeesWithDepartmentAndPositionSpecification(employeeSpecificationParams);

            var specificationForCount = new EmployeesForCountSpecification(employeeSpecificationParams);

            var employees = await _employeeRepository.GetAllWithSpecificationAsync(specification);

            var count = await _employeeRepository.CountAsync(specificationForCount);

            var data = _mapper.Map<IReadOnlyList<EmployeeViewModel>>(employees);

            return Ok(new Pagination<EmployeeViewModel>(employeeSpecificationParams.CurrentPage, employeeSpecificationParams.PageSize, count, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployeeById(Guid id)
        {
            var specification = new EmployeesWithDepartmentAndPositionSpecification(id);

            var employee = await _employeeRepository.GetByIdWithSpecificationAsync(specification);

            return Ok(_mapper.Map<EmployeeViewModel>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> CreateEmployee(CreateEmployeeViewModel createEmployeeViewModel)
        {
            var employee = _mapper.Map<Employee>(createEmployeeViewModel);

            await _employeeRepository.AddAsync(employee);

            return Ok(_mapper.Map<EmployeeViewModel>(employee));
        }
    }
}
