using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers;

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
        Message words = new Message()
        {
            MyMessage = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Velit rem exercitationem vitae error, porro quia necessitatibus non, hic ab neque temporibus labore quo! Aut harum atque quisquam, dolorem recusandae error!"
        };

        return View(words);
    }

    [HttpGet("Numbers")]
    public IActionResult Numbers()
    {
        int[] numbers = new int[]
        {
            1,2,3,4,5
        };
        return View(numbers);
    }

    [HttpGet("User")]
    public IActionResult User()
    {
        User Nick = new User()
        {
            Name = "Nicholas Gibson"
        };
        return View(Nick);
    }

    [HttpGet("Users")]
    public IActionResult Users()
    {
        User user01 = new User()
        {
            Name = "Nicholas Gibson"
        };
        User user02 = new User()
        {
            Name = "Cliff Helms"
        };
        User user03 = new User()
        {
            Name = "Kevin Dang"
        };
        List<User> userList = new List<User>(){user01,user02,user03};

        return View(userList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
