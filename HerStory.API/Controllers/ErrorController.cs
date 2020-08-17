using HerStory.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}