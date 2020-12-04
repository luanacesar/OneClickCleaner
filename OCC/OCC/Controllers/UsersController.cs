using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OCC.Models.ViewModels;


namespace OCC.Models
{
    public class UsersController : Controller
    {
        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;

        public UsersController(UserManager<AppUser> userMgr,
            IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passValid,
            IPasswordHasher<AppUser> passwordHash)
        {
            userManager = userMgr;//UserManager is the one that is going to content User Model and password
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        //public ViewResult Create() => View();
        //Metodo original:
        //public async Task<IActionResult> Create(UserModel userModel)
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                byte[] value;
                bool isValueAvailable = HttpContext.Session.TryGetValue("AdminCleaner", out value);

                if (isValueAvailable)
                {
                    Cleaner cleaner = JsonSerializer.Deserialize<Cleaner>(value);

                    //AppUser just contain Name Email and others
                    //User Model it is going to contain AppUser and Password
                    AppUser appUser = new AppUser
                    {
                        UserName = cleaner.UserName,
                        Email = cleaner.Email
                    };

                    IdentityResult result = await userManager.CreateAsync(
                        appUser, cleaner.Password);//User Manager is the one that contain appUser and password

                    if (result.Succeeded)
                    {
                        return RedirectToAction("DisplayCleanerList", "Admin");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View("Edit", "Admin");
        }

        //Creating New Potential cleaner (Identity Database)
        public async Task<IActionResult> CreatePotentialCleaner()
        {
            if (ModelState.IsValid)
            {
                byte[] value;
                bool isValueAvailable = HttpContext.Session.TryGetValue("potentialCleaner", out value);

                if (isValueAvailable)
                {
                    Cleaner cleaner = JsonSerializer.Deserialize<Cleaner>(value);

                    //AppUser just contain Name Email and others
                    //User Model it is going to contain AppUser and Password
                    AppUser appUser = new AppUser
                    {
                        UserName = cleaner.UserName,
                        Email = cleaner.Email
                    };

                    IdentityResult result = await userManager.CreateAsync(
                        appUser, cleaner.Password);//User Manager is the one that contain appUser and password

                    if (result.Succeeded)
                    {
                        return View("../Cleaner/CleanerCheckOut", cleaner);
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View("../Cleaner/CleanerDetail");
        }

        //Delete users
        public async Task<IActionResult> Delete()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("AdminCleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner = JsonSerializer.Deserialize<Cleaner>(value);

                AppUser user = await userManager.FindByEmailAsync(cleaner.Email);
                if (user != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("DisplayCleanerList", "Admin");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
            }
            return View("Edit", "Admin");

        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("AdminCleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner1 = JsonSerializer.Deserialize<Cleaner>(value);
                AppUser user = await userManager.FindByEmailAsync(cleaner1.Email);
                if (user != null)
                {
                    user.Email = cleaner1.Email;
                    IdentityResult validEmail
                        = await userValidator.ValidateAsync(userManager, user);
                    if (!validEmail.Succeeded)
                    {
                        AddErrorsFromResult(validEmail);
                    }
                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(cleaner1.Password))
                    {
                        validPass = await passwordValidator.ValidateAsync(userManager,
                            user, cleaner1.Password);
                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = passwordHasher.HashPassword(user,
                                cleaner1.Password);
                        }
                        else
                        {
                            AddErrorsFromResult(validPass);
                        }
                    }
                    if ((validEmail.Succeeded && validPass == null)
                            || (validEmail.Succeeded
                            && cleaner1.Password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
            }
            return RedirectToAction();

        }
public async Task<IActionResult> SaveUser()
        {            
           byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("cleaner", out value);
           
            if (isValueAvailable)
            {
                Cleaner cleaner1 = JsonSerializer.Deserialize<Cleaner>(value);
                AppUser user = await userManager.FindByEmailAsync(cleaner1.Email);
                if (user != null)
                {
                    user.Email = cleaner1.Email;
                    IdentityResult validEmail
                        = await userValidator.ValidateAsync(userManager, user);
                    if (!validEmail.Succeeded)
                    {
                        AddErrorsFromResult(validEmail);
                    }
                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(cleaner1.Password))
                    {
                        validPass = await passwordValidator.ValidateAsync(userManager,
                            user, cleaner1.Password);
                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = passwordHasher.HashPassword(user,
                                cleaner1.Password);
                        }
                        else
                        {
                            AddErrorsFromResult(validPass);
                        }
                    }
                    if ((validEmail.Succeeded && validPass == null)
                            || (validEmail.Succeeded
                            && cleaner1.Password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
            }
            return View("Edit", "Admin");
        }

        public async Task<IActionResult> SaveAdminUser()
        {
            byte[] value;
            bool isValueAvailable = HttpContext.Session.TryGetValue("AdminCleaner", out value);

            if (isValueAvailable)
            {
                Cleaner cleaner1 = JsonSerializer.Deserialize<Cleaner>(value);
                AppUser user = await userManager.FindByEmailAsync(cleaner1.Email);
                if (user != null)
                {
                    user.Email = cleaner1.Email;
                    IdentityResult validEmail
                        = await userValidator.ValidateAsync(userManager, user);
                    if (!validEmail.Succeeded)
                    {
                        AddErrorsFromResult(validEmail);
                    }
                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(cleaner1.Password))
                    {
                        validPass = await passwordValidator.ValidateAsync(userManager,
                            user, cleaner1.Password);
                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = passwordHasher.HashPassword(user,
                                cleaner1.Password);
                        }
                        else
                        {
                            AddErrorsFromResult(validPass);
                        }
                    }
                    if ((validEmail.Succeeded && validPass == null)
                            || (validEmail.Succeeded
                            && cleaner1.Password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("DisplayCleanerList", "Admin");
                        }
                        else
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
            }
            return View("Edit", "Admin");

        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)//Maybe de password fail, email fail because there is a duplicate
            {
                ModelState.AddModelError("", error.Description);
            }
        }


    }
}
