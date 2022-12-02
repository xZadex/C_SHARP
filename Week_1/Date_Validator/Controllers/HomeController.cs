using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Date_Validator.Models;

namespace Date_Validator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Success()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(Form newForm)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
