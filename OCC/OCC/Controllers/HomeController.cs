using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using OCC.Models;

namespace OCC.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository customerRepository;
        private ICleanerRepository cleanerRepository;
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMgr, ICustomerRepository customerRepo, ICleanerRepository cleanerRepo)
        {
            customerRepository = customerRepo;
            cleanerRepository = cleanerRepo;
            userManager = userMgr;
        }
        public ViewResult Index()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("cleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner1 = JsonSerializer.Deserialize<Cleaner>(value);
                return View(cleaner1);
            }

            return View(new Cleaner());
        }

        public ViewResult PotentialCleanerForm()
        {
            return View();
        }


    }
}
