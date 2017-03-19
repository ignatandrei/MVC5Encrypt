using MVCEncrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEncryptDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [MVCDecryptFilter(secret = "mySecret")]
        public ActionResult TestEncrypt(int a, string b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "An application made by Andrei Ignat";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}