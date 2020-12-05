using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace OCC.Controllers
{
    public class CleanerController : Controller
    {
        private ICleanerRepository cleanerRepository;

        //private IOrderRepository orderRepository;
        //private ICustomerRepository customerRepository;
        //private IServiceRepository serviceRepository;
        //private Customer customerCreatedRepo;


        public CleanerController(ICleanerRepository cleanerRepo)
        //, IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo)
        {
            cleanerRepository = cleanerRepo;
            //orderRepository = orderRepo;
            //customerRepository = customerRepo;
            //serviceRepository = serviceRepo;
        }

        [HttpPost]
        public IActionResult CleanerDetail(Cleaner cleaner)
        {
            cleaner.UserName = cleaner.FirstName;
            cleaner.Password = "Cleaner123@";
            //byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(cleaner);
            //HttpContext.Session.Set("cleaner", jsonOrder);
            byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(cleaner);
            HttpContext.Session.Set("potentialCleaner", jsonOrder);
            cleanerRepository.SaveCleaner(cleaner);

            //return RedirectToAction("CleanerCheckOut", cleaner);

            return RedirectToAction("CreatePotentialCleaner", "Users");

        }
        [HttpGet]
        public IActionResult CleanerDetail()
        {
            return View("CleanerDetail", new Cleaner());
        }
        //public ViewResult CleanerCheckOut(Cleaner cleaner)
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult RegisteredCleanerDetails()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("cleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner = JsonSerializer.Deserialize<Cleaner>(value);
                return View(cleaner);
            }
            return View(new Cleaner());
        }

        [HttpPost]
        public IActionResult RegisteredCleanerDetails(Cleaner cleaner)
        {
            if (ModelState.IsValid)
            {
                cleanerRepository.SaveCleaner(cleaner);
                TempData["message"] = $"{cleaner.FirstName} has been saved!";

                byte[] jsonCleanerEdit = JsonSerializer.SerializeToUtf8Bytes(cleaner);
                HttpContext.Session.Set("cleaner", jsonCleanerEdit);
                return RedirectToAction("SaveUser", "Users");
            }
            else
            {
                return View(cleaner);
            }
        }
    }

}

