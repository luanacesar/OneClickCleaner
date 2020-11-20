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

        [HttpPost("CleanerDetail")]
        public IActionResult CleanerDetail(Cleaner cleaner)
        {
            byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(cleaner);
            HttpContext.Session.Set("cleaner", jsonOrder);
            cleanerRepository.SaveCleaner(cleaner);
            //return RedirectToAction("CleanerCheckOut", cleaner);
            return View("CleanerCheckOut", cleaner);
        }
        [HttpGet("CleanerDetail")]
        public IActionResult CleanerDetail()
        {
            return View("CleanerDetail", new Cleaner());
        }
        //public ViewResult CleanerCheckOut(Cleaner cleaner)
        //{
        //    return View();
        //}
    }

 }

