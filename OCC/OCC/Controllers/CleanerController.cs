using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Controllers
{
    public class CleanerController : Controller
    {
        public ViewResult Cleaner()
        {
            return View();
        }
    }
}
