using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;
using prjMVC_Core.ViewModels;
using System.Diagnostics;

namespace prjMVC_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModels vm)
        {
            dbDemoContext db = new dbDemoContext();
            TPainent x = db.TPainents.FirstOrDefault(T=>T.FEmail.Equals(vm.txtAccount) && T.FPassword.Equals(vm.txtPassword));
            if (x != null)
            {
                if (x.FPassword.Equals(vm.txtPassword) && x.FEmail.Equals(vm.txtAccount))
                {
                    string json = System.Text.Json.JsonSerializer.Serialize(x);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }




        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
}