using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;
public class MainController : Controller
{

    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }
}