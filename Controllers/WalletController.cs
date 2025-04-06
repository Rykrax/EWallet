using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EWallet.Models;

namespace EWallet.Controllers;

public class WalletController : Controller
{
    private readonly ILogger<WalletController> _logger;

    public WalletController(ILogger<WalletController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return RedirectToAction("login");
    }

    [HttpGet("/login")]
    public IActionResult login()
    {
        return View();
    }

    [HttpGet("/register")]
    public IActionResult register()
    {
        return View();
    }

    // [HttpGet("/home")]
    // public IActionResult home()
    // {
    //     return View();
    // }


    [HttpGet("/user/profile")]
    public IActionResult profile()
    {
        return View();
    }

    [HttpGet("/user/setting")]
    public IActionResult setting()
    {
        return View();
    }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
