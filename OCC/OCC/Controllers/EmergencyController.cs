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
        public IActionResult ServiceDetail(Order order)
        {
            byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
            HttpContext.Session.Set("order", jsonOrder);

            return RedirectToAction("Get", "Emergency");
        }

            //// GET
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
                customerCreatedRepo = customerRepository.Customers.FirstOrDefault(r => r.Email == customer.Email);
                
                byte[] value;                 
                bool isValueAvailable = HttpContext.Session.TryGetValue("order", out value);
                if (isValueAvailable)
                {Order orderContact = JsonSerializer.Deserialize<Order>(value);                    
                    orderContact.CustomerId = customerCreatedRepo.CustomerId;
                    orderRepository.SaveOrder(orderContact);
                    return View("CheckOut", orderContact);
                }
                return View();
            }
            else
            {
                return View();
            }
            
        }
        
    }        
    
}