using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System.Text.Json;


namespace OCC.Controllers
{

    public class EmergencyController : Controller
    {
        // GET
        [HttpGet("Emergency")]
        public IActionResult Get()
        {
            return View("Index");
        }

        [HttpPost("Emergency")]
        public IActionResult Save(Customer customer)
        {
            byte[] jsonCustomer = JsonSerializer.SerializeToUtf8Bytes(customer);
            HttpContext.Session.Set("customer",jsonCustomer);
            return RedirectToAction("Index", "Home");
        }        
    }
}