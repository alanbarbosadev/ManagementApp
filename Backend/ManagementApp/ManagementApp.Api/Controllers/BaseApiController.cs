using ManagementApp.Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Data != null) return Ok(result.Data);

            if (result.IsSuccess && result.Data == null) return NotFound();

            return BadRequest(result.Error);
        }
    }
}
