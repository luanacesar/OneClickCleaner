using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System.Text.Json;


namespace OCC.Controllers
{

    public class PotentialCleanerController : Controller
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Save(PotentialCleaner potentialCleaner)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            byte[] jsonPotentialCleaner = JsonSerializer.SerializeToUtf8Bytes(potentialCleaner);
            HttpContext.Session.Set("potentialCleaner", jsonPotentialCleaner);
            return RedirectToAction("Index", "Home");
        }
    }
}