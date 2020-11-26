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
        private ICleanerRepository cleanerRepository;

        private Customer customerCreatedRepo;
        

        public EmergencyController( IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo, ICleanerRepository cleanerRepo)
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
        public IActionResult ServiceDetail(Order order)
        {
            if (ModelState.IsValid)
            {
                order.ServiceDay = DateTime.Now.Date;
                TimeSpan timeOrder = DateTime.Now.TimeOfDay;
                //TimeSpan timeOrder = new TimeSpan(7,0,0);

                IEnumerable<Cleaner> filterCustomerCleaner;
                if (timeOrder > new TimeSpan(6, 0, 0) && timeOrder < new TimeSpan(12, 0, 0))
                {
                    order.ShiftTime = "Afternoon";
                    filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                            where f.Location == order.Location &&
                                            f.Afternoon == true
                                            && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                            && f.IsCleaner == true
                                            select f;
                }
                else if (timeOrder >= new TimeSpan(12, 0, 0) && timeOrder < new TimeSpan(18, 0, 0))
                {
                    order.ShiftTime = "Evening";
                    filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                            where f.Location == order.Location &&
                                            f.Evening == true
                                            && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                            && f.IsCleaner == true
                                            select f;
                }
                else if (timeOrder >= new TimeSpan(18, 0, 0) && timeOrder < new TimeSpan(24, 0, 0))
                {

                    order.ShiftTime = "Night"; 
                    filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                            where f.Location == order.Location &&
                                            f.Night == true
                                            && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                            && f.IsCleaner == true
                                            select f;
                }
                else
                {
                    order.ShiftTime = "Morning";
                    filterCustomerCleaner = from f in cleanerRepository.Cleaners
                                            where f.Location == order.Location &&
                                            f.Morning == true
                                            && f.Weekends == (order.ServiceDay.DayOfWeek == DayOfWeek.Sunday || order.ServiceDay.DayOfWeek == DayOfWeek.Saturday)
                                            && f.IsCleaner == true
                                            select f;
                }               


                var filterOrderCleaner = from cleanerTable in filterCustomerCleaner
                                         join ordertable in orderRepository.Orders on cleanerTable.CleanerId equals ordertable.CleanerId
                                         where ordertable.ServiceDay.Date == order.ServiceDay.Date && ordertable.ShiftTime == order.ShiftTime
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


                if (!availableCleaner.Any())
                {
                    return View("NoCleanerAvailable");
                }
                order.CleanerId = availableCleaner.First<Cleaner>().CleanerId;

                byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(order);
                HttpContext.Session.Set("order", jsonOrder);

                return RedirectToAction("Get", "Emergency");
            }
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
            const int EMERGENCY_SERV_ID = 1;

            if (ModelState.IsValid)
            {
                customerRepository.SaveCustomer(customer);
                                
                byte[] value;                 
                bool isValueAvailable = HttpContext.Session.TryGetValue("order", out value);
                if (isValueAvailable)
                {   Order orderContact = JsonSerializer.Deserialize<Order>(value);
                    //Filling Order Information
                    orderContact.CustomerId = customer.CustomerId;
                    orderContact.ServiceId = EMERGENCY_SERV_ID;
                    orderContact.OrderPaymentState = "no payed";

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