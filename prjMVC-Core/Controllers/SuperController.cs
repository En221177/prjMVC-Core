using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using prjMVC_Core.Models;

namespace prjMVC_Core.Controllers
{
    public class SuperController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            if (HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER) == null)
            {
                Response.Redirect("/Home/Login");
                //RedirectToAction("Login", "Home");

            }



        }
    }
}
