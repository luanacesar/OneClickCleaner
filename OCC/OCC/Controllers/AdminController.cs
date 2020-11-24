using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCC.Models;
using System.Text.Json;

namespace OCC.Controllers
{
    public class AdminController : Controller
    {
        private ICleanerRepository cleanerRepository;

        public AdminController(ICleanerRepository repo)
        {
            cleanerRepository = repo;
        }
        public ViewResult DisplayCleanerList() => View(cleanerRepository.Cleaners);

        public ViewResult Edit(int cleanerId) =>
           View(cleanerRepository.Cleaners
               .FirstOrDefault(p => p.CleanerId == cleanerId));

        [HttpPost]
        public IActionResult Edit(Cleaner cleaner)
        {
            if (ModelState.IsValid)
            {
                cleanerRepository.SaveCleaner(cleaner);
                TempData["message"] = $"{cleaner.FirstName} has been saved!";
                return RedirectToAction("DisplayCleanerList");
            }
            else
            {
                return View(cleaner);
            }
        }

        public ViewResult Create() => View("Edit", new Cleaner());

        [HttpPost]
        public IActionResult Delete(int CleanerId)
        {
            Cleaner deleteCleaner = cleanerRepository.DeleteCleaner(CleanerId);

            if (deleteCleaner != null)
            {
                TempData["message"] = $"{deleteCleaner.FirstName} was deleted!";
            }

            return RedirectToAction("DisplayCleanerList");
        }


    }
}
