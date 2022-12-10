// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Controllers;
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
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View(MyModel);
    }

    [HttpGet("categories")]
    public IActionResult Category()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };
        return View(MyModel);
    }


    [HttpGet("products/{ProductId}")]
    public IActionResult ShowProduct(int ProductId)
    {
        ViewBag.AllCategories = _context.Categories.Include(c => c.ProductsList).Where(c => c.ProductsList.All(a => a.ProductId != ProductId));

        Association myAssociation = new Association();
        myAssociation.ProductId = ProductId;

        MyViewModel MyModel = new MyViewModel
        {
            Product = _context.Products.Include(e => e.CategoryList).ThenInclude(e => e.Category).FirstOrDefault(p => p.ProductId == ProductId),
            Association = myAssociation
        };
        return View(MyModel);
    }

    [HttpGet("categories/{CategoryId}")]
    public IActionResult ShowCategory(int CategoryId)
    {
        ViewBag.AllProducts = _context.Products.Include(c => c.CategoryList).Where(c => c.CategoryList.All(a => a.CategoryId != CategoryId));

        Association myAssociation = new Association();
        myAssociation.CategoryId = CategoryId;

        MyViewModel MyModel = new MyViewModel
        {
            Category = _context.Categories.Include(e => e.ProductsList).ThenInclude(e => e.Product).FirstOrDefault(p => p.CategoryId == CategoryId),
            Association = myAssociation
        };
        return View("ShowCategory",MyModel);
    }


    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllProducts = _context.Products.ToList()
            };
            return View("Index", MyModel);
        }
    }



    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllCategories = _context.Categories.ToList()
            };
            return View("Category", MyModel);
        }
    }


    [HttpPost("associations/create")]
    public IActionResult CreateAssociation(Association newCategoryItem)
    {
            _context.Add(newCategoryItem);
            _context.SaveChanges();
            return RedirectToAction("ShowProduct", new{ProductId = newCategoryItem.ProductId});
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
