using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OCC.Controllers;
using OCC.Models;
using System;
using System.Linq;

namespace OCC.UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
        private EFCleanerRepository repository;
        private Cleaner cleaner;
        private ApplicationDbContext dbContext;
        [TestInitialize]
        public void Startup()
        {
            dbContext = MvcMockHelpers.GetMockDbContext();
            // delete all data from cleaners
            dbContext.Cleaners.RemoveRange(dbContext.Cleaners);
            repository = new EFCleanerRepository(dbContext);
            cleaner = new Cleaner
            {
                Afternoon = true,
                Certificate = "Certificate",
                Evening = false,
                Location = "Location",
                Password = "Password",
                ExperienceLevel = "ExperienceLevel",
                FirstName = "FirstName",
                UserName = "UserName",
                Email = "Email@gmail.com"
            };
        }
        [TestMethod]
        public void TestAddCleanerActions()
        {
            var controller = new AdminController(repository);
            MvcMockHelpers.SetMockControllerContext(controller, null);
            var result = controller.Edit(cleaner);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var action = (RedirectToActionResult)result;
            Assert.AreEqual(action.ControllerName, "Users");
            Assert.AreEqual(action.ActionName, "Create");
        }

        [TestMethod]
        public void TestAddCleaner()
        {
            var controller = new AdminController(repository);
            MvcMockHelpers.SetMockControllerContext(controller, null);
            var result = controller.Edit(cleaner);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var action = (RedirectToActionResult)result;
            var savedCleaner = repository.Cleaners.FirstOrDefault();
            Assert.AreEqual(cleaner.UserName, savedCleaner.UserName);
        }

    }
}