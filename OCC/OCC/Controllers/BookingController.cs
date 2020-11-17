using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCC.Models;

namespace OCC.Controllers
{
    public class BookingController : Controller
    {

        private IOrderRepository orderRepository;
        private ICustomerRepository customerRepository;
        private IServiceRepository serviceRepository;

        private Customer customerCreatedRepo;


        public BookingController(IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo)
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

           /* byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
            HttpContext.Session.Set("order", jsonOrder);

            return RedirectToAction("Get", "Emergency");*/
           return RedirectToAction( );
        }
        
    }
}
