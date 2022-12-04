using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

public class HomeController : Controller
{

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

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }


    [HttpGet("results")]
    public IActionResult Results()
    {
        if(HttpContext.Session.GetString("UserName") == null)
        {
            return View("Index");
        } else {
            return View("Results");
        }
    }

    [HttpPost("process")]
    public IActionResult Process(string Name)
    {
        if(ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", Name);
            HttpContext.Session.SetInt32("favNum",22);
            return RedirectToAction("Results");
        }
        else
        {
            return View("Index");
        }

    }

    [HttpPost("logout")]
    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("domath")]
    public IActionResult DoMath(string operation)
    {
        if(operation == "+")
        {
            int? IntVariable = HttpContext.Session.GetInt32("favNum");
            IntVariable++;
            int result = IntVariable ?? default(int);
            HttpContext.Session.SetInt32("favNum",result);
            return RedirectToAction("Results");
        } 
        else if(operation == "-")
        {
            int? IntVariable = HttpContext.Session.GetInt32("favNum");
            IntVariable--;
            int result = IntVariable ?? default(int);
            HttpContext.Session.SetInt32("favNum",result);
            return RedirectToAction("Results");
        }
        else if(operation == "x")
        {
            int? IntVariable = HttpContext.Session.GetInt32("favNum");
            IntVariable *= 2;
            int result = IntVariable ?? default(int);
            HttpContext.Session.SetInt32("favNum",result);
            return RedirectToAction("Results");
        }
        else if(operation == "+random")
        {
            int? IntVariable = HttpContext.Session.GetInt32("favNum");
            Random rand = new Random();
            IntVariable += rand.Next(1,100);
            int result = IntVariable ?? default(int);
            HttpContext.Session.SetInt32("favNum",result);
            return RedirectToAction("Results");
        }
        else {
            return RedirectToAction("Results");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
