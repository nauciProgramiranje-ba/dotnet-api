using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class QuestionController : ControllerBase
{
    // GET: /<controller>/
    [HttpGet]
    public IActionResult GetAllQuestions()
    {
        return Ok();
    }
}

