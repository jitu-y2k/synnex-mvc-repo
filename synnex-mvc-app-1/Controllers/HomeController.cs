using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using synnex_mvc_app_1.Models;
using synnex_mvc_app_1.ViewModels;

namespace synnex_mvc_app_1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISession _session;

    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext)
    {
        _logger = logger;
        _session = httpContext.HttpContext.Session;
    }

    public IActionResult Index()
    {

        //ViewBag.WebSiteName = "New Web Application";
        
        var tmpData = TempData["UserInfo"];
        //_session.SetString("data", "This is mydata");
        

        var student = new Student
        {
            Name = "Keshav",
            Age= 20
        };

        //var studentwithSubjects = new StudentWithSubjects()
        //{
        //    Student = student,
        //    Subjects = new List<string>() { "English", "Maths"}
        //};

        //ViewData["student"] = student;
        ViewBag.tmpData = tmpData==null?null:JsonConvert.DeserializeObject<User>(tmpData?.ToString());


        return View();
    }

    public IActionResult Privacy()
    {
        TempData["mydata"] = "Coming from Privacy method";
        ViewBag.data = _session.GetString("data");
        return View();
        //return RedirectToAction("Index");
    }

    public IActionResult UserInfo()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UserInfo(User user)
    {
        TempData["UserInfo"] = JsonConvert.SerializeObject(user);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

