using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;

namespace OCC.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Emergency()
        {
            return View();
        }

        public ViewResult Booking()
        {
            return View();
        }

        public ActionResult CustomerForm()
        {
            return RedirectToAction("Get", "Emergency");
        }
    }
}
