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

        private Order cartOrder=new Order();
        private Customer customerCreatedRepo;

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
            cartOrder = order;
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
            return View("CustomerInfo", new Customer());
        }        

        [HttpPost("Emergency")]
        public IActionResult Save(Customer customer)
        {            
            if (ModelState.IsValid)
            {
                customerRepository.SaveCustomer(customer);
                customerCreatedRepo = customerRepository.Customers.FirstOrDefault(r => r.FullName == customer.FullName);
                cartOrder.CustomerId = customerCreatedRepo.CustomerId;
                return RedirectToAction("CheckOut");
            }
            else
            {
                return View();
            }
            
        }   
        
        public ViewResult CheckOut()
        {
            return View(cartOrder);
        }
    }
}