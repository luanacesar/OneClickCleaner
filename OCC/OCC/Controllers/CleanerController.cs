using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace OCC.Controllers
{
    //Cleaner controller is used to provide Potential cleaner and Registered Cleaners
    // the forms to fill out at first time and the form to edit for the already 
    // registered. Once they submit the information is send it to UserController
    // to create or update Identity profiles. In the case of potential cleaners
    // a generic password is created. The list of cleaners is going to be stored
    // in the database. 
    // The identity will be created by sending the information to the controller by Jason serialization
    public class CleanerController : Controller
    {
        private ICleanerRepository cleanerRepository;

        public CleanerController(ICleanerRepository cleanerRepo)
        {
            cleanerRepository = cleanerRepo;
        }

        [HttpPost]
        public IActionResult CleanerDetail(Cleaner cleaner)
        {
            cleaner.UserName = cleaner.FirstName;
            cleaner.Password = "Cleaner123@";
      
            byte[] jsonOrder = JsonSerializer.SerializeToUtf8Bytes(cleaner);
            HttpContext.Session.Set("potentialCleaner", jsonOrder);
            cleanerRepository.SaveCleaner(cleaner);

            return RedirectToAction("CreatePotentialCleaner", "Users");

        }
        [HttpGet]
        public IActionResult CleanerDetail()
        {
            return View("CleanerDetail", new Cleaner());
        }
  
        [HttpGet]
        public IActionResult RegisteredCleanerDetails()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("cleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner = JsonSerializer.Deserialize<Cleaner>(value);
                return View(cleaner);
            }
            return View(new Cleaner());
        }
        
    }

}

