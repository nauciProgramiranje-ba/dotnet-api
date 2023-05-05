using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ChapterController : ControllerBase
{
    // GET: /<controller>/
    [HttpGet]
    public IActionResult GetAllChapters()
    {
        return Ok();
    }
}

