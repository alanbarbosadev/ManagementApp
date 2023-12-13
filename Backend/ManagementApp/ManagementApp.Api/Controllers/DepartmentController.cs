using ManagementApp.Api.Errors;
using ManagementApp.Application.Features.Departments.Commands.CreateDepartment;
using ManagementApp.Application.Features.Departments.Queries.GetAllDepartments;
using ManagementApp.Application.Shared.Dtos.Departments;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class DepartmentController : BaseApiController
    {
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDepartments()
        {
            return HandleResult(await Mediator.Send(new GetAllDepartmentsQuery()));
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentDto departmentDto)
        {
            return HandleResult(await Mediator.Send(new CreateDepartmentCommand(departmentDto)));
        }
    }
}
