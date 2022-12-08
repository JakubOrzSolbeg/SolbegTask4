using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("")]

public class HomeController : ControllerBase
{
    [HttpGet]
    public RedirectResult Index()
    {
        return Redirect("/swagger");
    }
    
}