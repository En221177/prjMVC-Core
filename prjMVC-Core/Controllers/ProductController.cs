using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;
using prjMVC_Core.ViewModels;

namespace prjMVC_Core.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(CKeywordViewModels vm)
        {
            dbDemoContext db = new dbDemoContext();
            string keyword = vm.txtKeyword;
            IEnumerable < TProduct > datas = null;
            if(keyword == null)
            {
                datas = from c in db.TProducts
                       select c;
            }
            else
            {
                datas = db.TProducts.Where(c=>c.FName.Contains(keyword)).ToList();
            }
            return View(datas);
        }

        public IActionResult Delete(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t=>t.FId ==id);
            if(prod != null) 
            {
                db.TProducts.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TProduct p)
        {
            dbDemoContext db = new dbDemoContext();
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
