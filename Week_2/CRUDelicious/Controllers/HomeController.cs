// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;
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
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View();
    }

    [HttpGet("dishes/{dishId}")]
    public IActionResult ShowDish(int dishId)
    {
        Dish? myDish = _context.Dishes.FirstOrDefault(e => e.DishId == dishId);
        return View(myDish);
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("NewDish");
        }
    }

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        return View(DishToEdit);
    }

    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish UpdatedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if(DishToUpdate == null)
        {
            return View("Index");
        }
        
        if(ModelState.IsValid)
        {
            DishToUpdate.Name = UpdatedDish.Name;
            DishToUpdate.Chef = UpdatedDish.Chef;
            DishToUpdate.Tastiness = UpdatedDish.Tastiness;
            DishToUpdate.Calories = UpdatedDish.Calories;
            DishToUpdate.Description = UpdatedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Redirect($"/dishes/{dishId}");
        } else {
            return View();
        }
    }

    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DestroyDish(int dishId)
    {
        Dish? DishToDestroy = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        _context.Dishes.Remove(DishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
