using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;
using prjMVC_Core.ViewModels;
using System.IO;
using static System.Net.WebRequestMethods;

namespace prjMVC_Core.Controllers
{
    public class ProductController : SuperController
    {
        private IWebHostEnvironment _environment;
        public ProductController(IWebHostEnvironment p)//介面不能new，可用注入
        {
            _environment = p;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(CKeywordViewModels vm)
        {
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            if (json == null)
            {
                return RedirectToAction("Login", "Home");

            }


            dbDemoContext db = new dbDemoContext();
            string keyword = vm.txtKeyword;
            IEnumerable<TProduct> datas = null;
            if (keyword == null)
            {
                datas = from c in db.TProducts
                        select c;
            }
            else
            {
                datas = db.TProducts.Where(c => c.FName.Contains(keyword)).ToList();
            }

            List<CProductViewModel> list = new List<CProductViewModel>();
            foreach (var d in datas)
            {
                CProductViewModel v = new CProductViewModel();
                v.Product = d;
                list.Add(v);
            }
            return View(list);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == id);
                if (prod != null)
                {
                    db.TProducts.Remove(prod);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CProductViewModel vm)
        {
            dbDemoContext db = new dbDemoContext();
            db.TProducts.Add(vm.Product);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == id);
                CProductViewModel vm = new CProductViewModel();
                vm.Product = prod;
                return View(vm);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(CProductViewModel vm)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == vm.FId);
            if (prod != null)
            {
                if (vm.photo != null) //參數要一致所以把Photo放在calss tProduct裡一起送進來
                {
                    string oldPath = _environment.WebRootPath + "/Images/" + prod.FPhotoPath;
                    if (System.IO.File.Exists(oldPath))//如果以存再就刪除
                        System.IO.File.Delete(oldPath);
                    string photoName = Guid.NewGuid().ToString() + ".jpg";//產生唯一字串
                    string path = _environment.WebRootPath + "/Images/" + photoName;
                    //清空資源
                    using(FileStream file = new FileStream(path, FileMode.Create))
                    {
                        prod.FPhotoPath = photoName;
                        vm.photo.CopyTo(file);
                    }


                    //prod.FPhotoPath = photoName;
                    //FileStream file = new FileStream(path, FileMode.Create);
                    //vm.photo.CopyTo(file);
                    //file.Dispose();
                }

                prod.FName = vm.FName;
                prod.FPrice = vm.FPrice;
                prod.FQty = vm.FQty;
                prod.FCost = vm.FCost;
                //prod.FPhotoPath = vm.FPhotoPath;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }



    }
}
