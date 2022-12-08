// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // Now any time we want to access our database we use _context   
        List<Chef> AllChefs = _context.Chefs.ToList();
        return View(AllChefs);
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        // Now any time we want to access our database we use _context   
        List<Dish> AllDishes = _context.Dishes.Include(a => a.ChefName).ToList();
        return View(AllDishes);
    }

    [HttpGet("chefs/new")]
    public IActionResult AddChef()
    {
        return View();
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("AddChef");
        }
    }

    [HttpGet("dishes/new")]
    public IActionResult AddDish()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        ViewBag.Chefs = allChefs;
        return View();
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        } else {
            List<Chef> allChefs = _context.Chefs.ToList();
            ViewBag.Chefs = allChefs;
            return View("AddDish");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
