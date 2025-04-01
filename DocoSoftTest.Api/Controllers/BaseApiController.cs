using DocoSoftTest.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace DocoSoftTest.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}