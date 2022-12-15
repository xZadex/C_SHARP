using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace TheWall.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("UserFirst", newUser.FirstName);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LPassword);

            if (result == 0)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserFirst", userInDb.FirstName);
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    [HttpGet("success")]
    public IActionResult Success()
    {
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        MyViewModel MyModel = new MyViewModel
        {
            AllMessages = _context.Messages.Include(u => u.Creator).ToList(),
            AllComments = _context.Comments.Include(u => u.Users).ThenInclude(u => u.User).ToList()
        };
        return View(MyModel);
    }

    [HttpPost("messages/new")]
    public IActionResult NewMessage(Message newMessage)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMessage);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View("Success");
        }
    }

    [HttpPost("messages/{id}/comments/new")]
    public IActionResult NewComment(int id,Comment newComment)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newComment);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View("Success");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
