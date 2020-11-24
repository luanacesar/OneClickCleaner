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
        private ICleanerRepository repository;

        public AdminController(ICleanerRepository repo)
        {
            repository = repo;
        }
        public ViewResult DisplayCleanerList() => View(repository.Cleaners);

        public ViewResult Edit(int cleanerId) =>
           View(repository.Cleaners
               .FirstOrDefault(p => p.CleanerId == cleanerId));

        [HttpPost]
        public IActionResult Edit(Cleaner cleaner)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCleaner(cleaner);
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
            Cleaner deleteCleaner = repository.DeleteCleaner(CleanerId);

            if (deleteCleaner != null)
            {
                TempData["message"] = $"{deleteCleaner.FirstName} was deleted!";
            }

            return RedirectToAction("DisplayCleanerList");
        }


    }
}
