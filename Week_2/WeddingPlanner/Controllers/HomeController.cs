using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Controllers;
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
        List<User> AllUsers = _context.Users.ToList();
        return View();
    }

    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()
    {
        WeddingAssociation myAssociation = new WeddingAssociation();
        MyViewModel MyModel = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(u => u.GuestList).ThenInclude(u => u.User).ToList(),
            WeddingAssociation = myAssociation
        };
        return View(MyModel);
    }

    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult PlanWedding()
    {
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        return View();
    }

    [SessionCheck]
    [HttpGet("weddings/{id}")]
    public IActionResult ShowWedding(int id)
    {
        WeddingAssociation myAssociation = new WeddingAssociation();
        myAssociation.WeddingId = id;

        MyViewModel MyModel = new MyViewModel
        {
            Wedding = _context.Weddings.Include(g => g.GuestList).ThenInclude(u => u.User).FirstOrDefault(w => w.WeddingId == id),
            WeddingAssociation = myAssociation,
        };
        return View(MyModel);
    }

    [SessionCheck]
    [HttpPost("weddings/new/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            int id = newWedding.WeddingId;
            return RedirectToAction("ShowWedding", new { id = newWedding.WeddingId });
        }
        else
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View("PlanWedding");
        }
    }

    [HttpPost("weddings/{id}/destroy")]
    public IActionResult DestroyWedding(int id)
    {
        Wedding? WeddingToDestroy = _context.Weddings.SingleOrDefault(d => d.WeddingId == id);
        _context.Weddings.Remove(WeddingToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [HttpPost("associations/weddings/{id}/create")]
    public IActionResult RSVP(int id)
    {
        WeddingAssociation association = new WeddingAssociation();
        association.UserId = (int)HttpContext.Session.GetInt32("UserId");
        association.WeddingId = id;
        _context.Add(association);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [HttpPost("associations/weddings/{id}/destroy")]
    public IActionResult UNRSVP(int id)
    {
        WeddingAssociation? AssociationToDestroy = _context.WeddingAssociations.SingleOrDefault(d => d.WeddingId == id && d.UserId == HttpContext.Session.GetInt32("UserId"));
        _context.WeddingAssociations.Remove(AssociationToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
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
            return RedirectToAction("Weddings");
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
                return RedirectToAction("Weddings");
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
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}