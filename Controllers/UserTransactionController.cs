using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserTransactionController : ControllerBase
{
    // GET: /<controller>/
    [HttpGet]
    public IActionResult GetAllUserTransactions()
    {
        return Ok();
    }
}

