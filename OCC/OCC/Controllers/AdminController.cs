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


    }
}
