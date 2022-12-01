using Microsoft.AspNetCore.Mvc;

namespace Dojo.Controllers;
public class DojoController : Controller
{

    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("result")]
    public ViewResult Result()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        if(Comment == null)
        {
            ViewBag.Comment = "No Comment";
        } else {
            ViewBag.Comment = Comment;
        }
        return View("result");
    }
}