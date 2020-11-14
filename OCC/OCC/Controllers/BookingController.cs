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

        public BookingController(IOrderRepository orderRepo, ICustomerRepository customerRepo, IServiceRepository serviceRepo)
        {
            orderRepository = orderRepo;
            customerRepository = customerRepo;
            serviceRepository = serviceRepo;
        }

        public ViewResult ServiceDetail()
        {
            return View();
        }
    }
}
