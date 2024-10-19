using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsFac;

namespace Proje_term.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    [HttpGet("About")]
    public IActionResult About() => View();
    [HttpGet("Contact")]
    public IActionResult Contact() => View();
    [HttpGet("Service")]
    public IActionResult Service() => View();
}