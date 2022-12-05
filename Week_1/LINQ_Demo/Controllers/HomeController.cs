using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQ_Demo.Models;

namespace LINQ_Demo.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[]
    {
        new Game {Title="Elden Ring", Price=59.99, Genre="RPG", Rating="M", Platform="PC"},
        new Game {Title="RuneScape", Price=0.00, Genre="MMORPG", Rating="E", Platform="PC"},
        new Game {Title="Pokemon GO", Price=0.00, Genre="Adventure", Rating="E", Platform="Mobile"},
        new Game {Title="Apex Legends", Price=0.00, Genre="FPS", Rating="E", Platform="PC"},
        new Game {Title="World Of Warcraft", Price=39.99, Genre="MMORPG", Rating="E", Platform="PC"},
        new Game {Title="Overwatch", Price=59.99, Genre="FPS", Rating="E", Platform="PC"},
        new Game {Title="Rust", Price=59.99, Genre="FPS", Rating="E", Platform="PC"},
        new Game {Title="Pokemon Sapphire", Price=20.00, Genre="Adventure", Rating="E", Platform="Gameboy Advanced"},
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // All PC Games
        List<Game> AllPCGames = AllGames.Where(game => game.Platform == "PC").ToList();
        ViewBag.AllPCGames = AllPCGames;

        // Get One Game
        Game? RuneScape = AllGames.FirstOrDefault(o => o.Title == "RuneScape");
        ViewBag.RS = RuneScape;

        // Get first 3 free games then order by name
        List<Game> Top3Free = AllGames.Where(g => g.Price == 0.00).OrderBy(t => t.Title).Take(3).ToList();
        ViewBag.TopFree = Top3Free;

        // Get the price of the most expensive game
        double MostExpensive = AllGames.Max(s => s.Price);
        ViewBag.MostExpensive = MostExpensive;

        // Now use that information to get game
        Game? MostExpensiveGame = AllGames.FirstOrDefault(o => o.Price == MostExpensive);
        

        // Add all the prices added together
        double Total = AllGames.Sum(p => p.Price);
        ViewBag.Total = Total;

        // Grab all the titles... just the titles, not the whole Game
        List<string> AllTitles = AllGames.OrderBy(t => t.Title).Select(s => s.Title).ToList();
        ViewBag.AllTitles = AllTitles;

        // We can get back a boolean whether a condition was met
        bool MatchTitle = AllGames.Any(s => s.Title == "RuneScape");
        ViewBag.MatchTitle = MatchTitle;
        return View();
    }

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
