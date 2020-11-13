using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;


namespace OCC.Controllers
{

    public class EmergencyController : Controller
    {
        private IOrderRepository orderRepository;
        private ICustomerRepository customerRepository;
        private IServiceRepository serviceRepository;

        public EmergencyController( IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo)
        {
            orderRepository = orderRepo;
            customerRepository = customerRepo;
            serviceRepository = serviceRepo;
        }
        
        public ViewResult ServiceDetail()
        {
            return View(new Order());
        }
        [HttpPost]
        public ActionResult ServiceDetail(Order order)
        {
            return RedirectToAction("Get", "Emergency");
        }

        public ActionResult CustomerInfo()
        {
            return RedirectToAction("Get", "Emergency");
        }

        // GET
        [HttpGet("Emergency")]
        public IActionResult Get()
        {
            return View("CustomerInfo");
        }        

        [HttpPost("Emergency")]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            byte[] jsonCustomer = JsonSerializer.SerializeToUtf8Bytes(customer);
            HttpContext.Session.Set("customer",jsonCustomer);
            return RedirectToAction("Index", "Home");
        }        
    }
}