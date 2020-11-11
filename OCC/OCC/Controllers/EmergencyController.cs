using Microsoft.AspNetCore.Mvc;

namespace OCC.Controllers
{
    public class EmergencyController : Controller
    {
        // GET
        [Route("Emergency")]
        public IActionResult Index()
        {
            return View();
        }
    }
}