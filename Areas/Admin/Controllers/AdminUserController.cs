using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RSI_Calendar.Models;
using RSI_Calendar.Areas.Admin.Models;

namespace RSI_Calendar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private CalendarContext context;
        public AdminUserController(UserManager<User> userMngr, RoleManager<IdentityRole> roleMngr, CalendarContext ctx)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            context = ctx;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Action = "Register";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new RSI_Calendar.Models.User
                {
                    UserName = model.email,
                    FirstName = model.fName,
                    LastName = model.lName,
                    Email = model.email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var employee = new RSI_Calendar.Models.Employee
                    {
                        FName = model.fName,
                        LName = model.lName,
                        Location = model.location,
                        Role = model.role,
                        Email = model.email
                    };

                    if(model.Role == "Admin")
                    {
                        IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
                        await userManager.AddToRoleAsync(user, adminRole.Name);
                    }
                    else if(model.Role == "CulAm")
                    {
                        IdentityRole culAmRole = await roleManager.FindByNameAsync("CulAm");
                        await userManager.AddToRoleAsync(user, culAmRole.Name);
                    }

                    context.Employees.Add(employee);
                    context.SaveChanges();

                    return View("Month");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var employee = context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.ID == 0) ;
                //handle if somehow the employee ID is 0 meaning this is a new employee and you shouldn't be able to do that
                else
                {
                    context.Employees.Update(employee);
                    context.SaveChanges();
                }

                return View("Month");
                                      
            }
            else
            {
                return View(employee);
            }


        }

        public IActionResult Delete()
        {
            return View("Delete");
        }

        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
