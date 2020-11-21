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
                Cleaner orderCleaner = new Cleaner();
                switch (order.ShiftTime)
                {
                    case "Morning":
                        orderCleaner.Morning = true;
                        break;
                    case "Afternoon":                        
                        orderCleaner.Afternoon = true;
                        break;
                    case "Evening":
                        orderCleaner.Evening = true;
                        break;
                    case "Night":
                        orderCleaner.Night = true;
                        break;
                    default:
                        break;
                }
                
                var filteCustomerCleaner = from f in cleanerRepository.Cleaners
                            where f.Location==order.Location &&
                            (f.Morning==orderCleaner.Morning || f.Afternoon == orderCleaner.Afternoon||f.Evening==orderCleaner.Evening||f.Night==orderCleaner.Night)
                            && f.Weekends==(order.ServiceDay.DayOfWeek==DayOfWeek.Sunday || order.ServiceDay.DayOfWeek==DayOfWeek.Saturday)
                            select f;
                var filterOrderCleaner = from cleanerTable in filteCustomerCleaner
                             join ordertable in orderRepository.Orders on cleanerTable.CleanerId equals ordertable.CleanerId
                             where ordertable.ServiceDay == order.ServiceDay && ordertable.ShiftTime==order.ShiftTime
                             select cleanerTable;
                var availableCleaner = new List<Cleaner>();
                bool noMatch = true;
                foreach (var item in filteCustomerCleaner)
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
            return View();
        }

        [HttpPost]
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
