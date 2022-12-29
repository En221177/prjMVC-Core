using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;
using prjMVC_Core.ViewModels;
using System.Text.Json;

namespace prjMVC_Core.Controllers
{
    public class CustomerController : SuperController
    {





        [HttpPost]
        public IActionResult Edit(TPainent P)
        {
            dbDemoContext db = new dbDemoContext();
            TPainent customer = db.TPainents.FirstOrDefault(t => t.Fld == P.Fld);
            if (customer != null)
            {             
                customer.FName = P.FName;
                customer.FPhone = P.FPhone;
                customer.FEmail = P.FEmail;
                customer.FAddress = P.FAddress;
                customer.FPassword = P.FPassword;
                customer.F身分證號 = P.F身分證號;
                customer.F健保卡號 = P.F健保卡號;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TPainent customer = db.TPainents.FirstOrDefault(t => t.Fld == id);
                if (customer != null)
                    return View(customer);

            }
            return RedirectToAction("List");
        }




        public IActionResult Delete(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TPainent customer = db.TPainents.FirstOrDefault(t => t.Fld == id);
            if (customer != null)
            {
                db.TPainents.Remove(customer);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }




        public IActionResult List(CKeywordViewModels vm)
        {
           
            dbDemoContext db = new dbDemoContext();
            string keyword =vm.txtKeyword;
            IEnumerable<TPainent> datas = null;
            if (keyword == null)
                datas = from c in db.TPainents
                        select c;
            else
                datas = db.TPainents.Where(c => c.FName.Contains(keyword)).ToList();
            return View(datas);
        }




        public IActionResult Craete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Craete(TPainent P)
        {
            dbDemoContext db = new dbDemoContext();
            db.TPainents.Add(P);
            db.SaveChanges();

            return RedirectToAction("List");
        }


    }
}
