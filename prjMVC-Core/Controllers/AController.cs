using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using prjMVC_Core.Models;
//using System.Text.Json;
using System.Diagnostics.Contracts;

namespace prjMVC_Core.Controllers
{
    public class AController : Controller
    {
        public string sealizeDemo()
        {
            TPainent x = new TPainent();
            x.FName = "Freddy";
            x.FPhone = "0954687251";
            string json = System.Text.Json.JsonSerializer.Serialize(x);
            return json;
        }
        public string DesealizeDemo()
        {
            TPainent x  = System.Text.Json.JsonSerializer.Deserialize<TPainent>("{\"Fld\":0,\"FName\":\"Freddy\",\"FPhone\":\"0954687251\",\"FEmail\":null,\"FAddress\":null,\"FPassword\":null,\"F\\u5065\\u4FDD\\u5361\\u865F\":null,\"F\\u8EAB\\u5206\\u8B49\\u865F\":null}");
            return x.FName;
        }

        //{"Fld":0,"FName":"Freddy","FPhone":"0954687251","FEmail":null,"FAddress":null,"FPassword":null,"F\u5065\u4FDD\u5361\u865F":null,"F\u8EAB\u5206\u8B49\u865F":null}

        public IActionResult showCountBlySession()
        {
            int count = 0;

            if (HttpContext.Session.Keys.Contains("COUNT"))
                count = (int)HttpContext.Session.GetInt32("COUNT");//讀取 Session 
            count++;
            HttpContext.Session.SetInt32("COUNT", count);//存入 Session s

            ViewBag.Count = count;
            return View();
        }

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
