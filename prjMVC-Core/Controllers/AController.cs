using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;

namespace prjMVC_Core.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult hi()
        {
            return View();
        }

        public string Lotto()
        {
            return(new CLottoGen()).getNumbers();
        }
    }
}
