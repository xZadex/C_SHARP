﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_With_Validations.Models;

namespace Dojo_Survey_With_Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static Survey? mySurvey;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("result")]
    public IActionResult Result()
    {
        return View(mySurvey);
    }

    [HttpPost("process")]
    public IActionResult Process(Survey newSurvey)
    {
        if(ModelState.IsValid)
        {
            mySurvey = newSurvey;
            return RedirectToAction("Result");
        }
        else
        {
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
