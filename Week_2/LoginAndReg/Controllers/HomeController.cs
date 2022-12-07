// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegDemo.Models;
namespace LoginAndRegDemo.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
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
        List<User> AllUsers = _context.Users.ToList();
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            // Hash Password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }

    [SessionCheck]
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }


    [HttpPost("users/login")]
    public IActionResult LoginUser(LoginUser loginUser)
    {
        if(ModelState.IsValid)
        {
            // Look up user in the db
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LEmail);
            // Verify it is a user who exists
            if(userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            // Verify the password matches what's in the db
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LPassword);

            if(result == 0)
            {
                // A failure message
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            } else {
                // set user to session and head to success
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Success");
            }
        } else {
            return View("Index");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if(userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}