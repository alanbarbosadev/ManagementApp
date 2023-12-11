using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
