using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private ICleanerRepository cleanerRepository;

        public BookingController(IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo, ICleanerRepository cleanerRepo)
        {
            orderRepository = orderRepo;
            customerRepository = customerRepo;
            serviceRepository = serviceRepo;
            cleanerRepository = cleanerRepo;
        }

        public ViewResult ServiceDetail()
        {
            return View(new Order());
        }
        [HttpPost]
        public ViewResult ServiceDetail(Order order)
        {
            const int BOOKING_SERV_ID = 2;
            
            if (ModelState.IsValid)
            {
                //Filling Order Information
                order.ServiceId = BOOKING_SERV_ID;
                order.OrderPaymentState = "no payed";

                //Save in the Database the order created
                orderRepository.SaveOrder(order);

                //Serialize the order information in order to send to the next controller
                byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
                HttpContext.Session.Set("order", jsonOrder);

                return View("SelectingCleaner", new Cleaner());
            }
            return View();

        }
        [HttpPost]
        public IActionResult SelectingCleaner(Cleaner cleaner)
        {
            

            cleanerRepository.SaveCleaner(cleaner);
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("order", out value);
            if (isValueAvailable)
            {
                Order orderContact = JsonSerializer.Deserialize<Order>(value);
                //Filling Order Information
                orderContact.CleanerId = cleaner.CleanerId;                

                //orderRepository.SaveOrder(orderContact);
                return View("CustomerInfo", new Customer());
            }
            return View();
        }
       
    }
}
