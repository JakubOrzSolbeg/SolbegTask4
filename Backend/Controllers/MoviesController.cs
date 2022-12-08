using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MoviesController : ControllerBase
{
    // Method for testing connection
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }


}