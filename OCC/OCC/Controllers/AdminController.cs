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

        public ViewResult EditCleaners(int cleanerId) =>
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

        public ViewResult Create() => View("EditCleaners", new Cleaner());

        //[HttpPost]
        //public IActionResult Delete(int productId)
        //{
        //    Product deletedProduct = repository.DeleteProduct(productId);

        //    if (deletedProduct != null)
        //    {
        //        TempData["message"] = $"{deletedProduct.Name} was deleted!";
        //    }

        //    return RedirectToAction("Index");
        //}


    }
}
