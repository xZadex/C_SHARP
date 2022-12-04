using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Form_Submission.Models;

namespace Form_Submission.Controllers;

public class HomeController : Controller
{
    static Survey? mySurvey;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(Survey newSurvey)
    {
        if(ModelState.IsValid)
        {
            mySurvey = newSurvey;
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
