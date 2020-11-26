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
                IEnumerable<Cleaner> filterCustomerCleaner;
                switch (order.ShiftTime)
                {
                    case "Morning":
                        filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                                   where f.Location == order.Location &&
                                                   f.Morning == true
                                                   && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                                   && f.IsCleaner == true
                                                   select f;
                        break;
                    case "Afternoon":                        
                        filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                                   where f.Location == order.Location &&
                                                   f.Afternoon == true
                                                   && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                                   && f.IsCleaner == true
                                                   select f;
                        break;
                    case "Evening":
                        filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                                   where f.Location == order.Location &&
                                                   f.Evening == true
                                                   && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                                   && f.IsCleaner == true
                                                   select f;
                        break;
                    default:
                        filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                                   where f.Location == order.Location &&
                                                   f.Night == true
                                                   && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                                   && f.IsCleaner == true
                                                   select f;
                        break;
                }

                
                var filterOrderCleaner = from cleanerTable in filterCustomerCleaner
                             join ordertable in orderRepository.Orders on cleanerTable.CleanerId equals ordertable.CleanerId
                             where ordertable.ServiceDay.Date == order.ServiceDay.Date && ordertable.ShiftTime==order.ShiftTime
                             select cleanerTable;
                var availableCleaner = new List<Cleaner>();
                bool noMatch = true;
                foreach (var item in filterCustomerCleaner)
                {
                    foreach (var item1 in filterOrderCleaner)
                    {
                        if (item.CleanerId == item1.CleanerId)
                        {
                            noMatch = false;
                        }
                    }
                    if (noMatch)
                    {
                        availableCleaner.Add(item);
                        
                    }
                    noMatch = true;
                }
                
                //Filling Order Information
                order.ServiceId = BOOKING_SERV_ID;
                order.OrderPaymentState = "no payed";                
                

                //Serialize the order information in order to send to the next controller
                byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
                HttpContext.Session.Set("order", jsonOrder);

                if (!availableCleaner.Any())
                {
                    return View("NoCleanerAvailable");
                }

                return View("SelectingCleaner", availableCleaner);

            }
            return View();

        }
        [HttpPost]
        public IActionResult SelectingCleaner(long CleanerId)
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("order", out value);
            if (isValueAvailable)
            {
                Order order = JsonSerializer.Deserialize<Order>(value);
                //Filling Order Information
                order.CleanerId = CleanerId;
                //Serialize the order information in order to send to the next controller
                byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
                HttpContext.Session.Set("order", jsonOrder);

                //orderRepository.SaveOrder(orderContact);
                return RedirectToAction("Get", "Booking");
            }
            return View();
        }
        [HttpGet("Booking")]
        public IActionResult Get()
        {
            return View("CustomerInfo", new Customer());
        }

        [HttpPost("Booking")]
        public IActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.SaveCustomer(customer);

                byte[] value;
                bool isValueAvailable = HttpContext.Session.TryGetValue("order", out value);
                if (isValueAvailable)
                {
                    Order orderContact = JsonSerializer.Deserialize<Order>(value);
                    //Filling Order Information
                    orderContact.CustomerId = customer.CustomerId;                  

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
