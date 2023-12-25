using ManagementApp.Api.Errors;
using ManagementApp.Application.Features.Employees.Commands.CreateEmployee;
using ManagementApp.Application.Features.Employees.Commands.CreateEmployees;
using ManagementApp.Application.Features.Employees.Queries.GetAllEmployeesWithSpecification;
using ManagementApp.Application.Features.Employees.Queries.GetEmployeeByIdWithSpecification;
using ManagementApp.Application.Shared.Dtos.Employees;
using ManagementApp.Application.Specifications.Employees;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeSpecificationParams employeeSpecificationParams)
        {
            return HandleResult(await Mediator.Send(new GetAllEmployeesWithSpecificationQuery(employeeSpecificationParams)));

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeById([FromQuery] Guid id)
        {
            return HandleResult(await Mediator.Send(new GetEmployeeByIdWithSpecificationQuery(id)));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            return HandleResult(await Mediator.Send(new CreateEmployeeCommand(employeeDto)));
        }

        [HttpPost("range")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployees([FromBody] List<CreateEmployeeDto> employeesDtos)
        {
            return HandleResult(await Mediator.Send(new CreateEmployeesCommand(employeesDtos)));
        }
    }
}
