using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class LessonController : ControllerBase
{
    // GET: /<controller>/
    [HttpGet]
    public IActionResult GetAllLessons()
    {
        return Ok();
    }
}

