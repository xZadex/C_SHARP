using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;
public class PortfolioController : Controller
{

    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View();
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View();
    }
}