using ManagementApp.Application.Features.Employees.Commands.CreateEmployee;
using ManagementApp.Application.Features.Employees.Queries.GetAllEmployeesWithSpecification;
using ManagementApp.Application.Features.Employees.Queries.GetEmployeeByIdWithSpecification;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos;
using ManagementApp.Application.Specifications.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<EmployeeDto>>> GetAllEmployees([FromQuery] EmployeeSpecificationParams employeeSpecificationParams)
        {
            var employees = await _mediator.Send(new GetAllEmployeesWithSpecificationQuery(employeeSpecificationParams));

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(Guid id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdWithSpecificationQuery(id));

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeCommand createEmployeeCommand)
        {
            return Ok(await _mediator.Send(createEmployeeCommand));
        }
    }
}
