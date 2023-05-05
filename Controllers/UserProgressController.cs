using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserProgressController : ControllerBase
{
    // GET: /<controller>/
    [HttpGet]
    public IActionResult GetAllUserProgress()
    {
        return Ok();
    }
}

