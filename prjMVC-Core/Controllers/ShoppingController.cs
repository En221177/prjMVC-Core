using Microsoft.AspNetCore.Mvc;
using prjMVC_Core.Models;
using prjMVC_Core.ViewModels;
using System.Text.Json;

namespace prjMVC_Core.Controllers
{
    public class ShoppingController : SuperController
    {
        public IActionResult List()
        {
            dbDemoContext db = new dbDemoContext();
            var datas = from c in db.TProducts
                        select c;

            return View(datas);
        }

        public ActionResult AddToCart(int? id)
        {
            ViewBag.fid = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel p)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == p.txtFid);
            if (prod == null)
                return RedirectToAction("List");

            List<CAddToCartItem> cart = null;
            string json = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
            {
                json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);//GetString=>session值進json
                cart = System.Text.Json.JsonSerializer.Deserialize<List<CAddToCartItem>>(json);//去序列化
            }
            else
                cart = new List<CAddToCartItem>();//如果是空的就new

            CAddToCartItem x = new CAddToCartItem();
            x.price = (decimal)prod.FPrice;
            x.productId = p.txtFid;
            x.count = p.txtCount;
            x.product = prod;
            cart.Add(x);
            json = System.Text.Json.JsonSerializer.Serialize(cart);//將物件轉json
            HttpContext.Session.SetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST, json);//json進Session，key=CDictionary.SK_PURCHASED_PRODUCTS_LIST , /Value=json
            return RedirectToAction("List");
        }


        //public ActionResult ShoppingView()
        //{
        //    List<CAddToCartItem> cart = Session[CDictionary.SK_PURCHASED_PRODUCTS_LIST] as List<CAddToCartItem>;
        //    if (cart == null)
        //        return RedirectToAction("List");
        //    return View(cart);
        //}

        //public ActionResult CartView()
        //{
        //    List<CAddToCartItem> cart = Session[CDictionary.SK_PURCHASED_PRODUCTS_LIST] as List<CAddToCartItem>;
        //    if (cart == null)
        //        return RedirectToAction("List");
        //    return View(cart);
        //}
    }
}
