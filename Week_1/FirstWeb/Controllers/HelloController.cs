using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers;
public class HelloController : Controller
{
    // Routing!!
    // This tells our controller we have a web page we want to see (or GET)
    [HttpGet]
    // What is the url?
    // this goes to localhost:5XXX/
    [Route("")]
    public ViewResult Index()
    {
        // ViewBag allows us to pass data from our controller to our view
        // Think of a viewbag as a dictionary it has keys and values
        ViewBag.Name = "Nicholas";
        ViewBag.Number = 7;
        return View("Index");
    }
    // localhost:5XXX/user/more
    [HttpGet("user/more")]
    public string AUser()
    {
        return "Even more information on User!";
    }

    [HttpGet("user/{id}")]
    public string OneUser(int id)
    {
        return $"This is user {id}";
    }
}