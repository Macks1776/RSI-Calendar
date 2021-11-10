using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RSI_Calendar.Models;
using RSI_Calendar.Areas.Admin.Models;
using System.Linq;

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
                    UserName = model.Email,
                    FirstName = model.FName,
                    LastName = model.LName,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var employee = new RSI_Calendar.Models.Employee
                    {
                        FName = model.FName,
                        LName = model.LName,
                        Branch = model.Branch,
                        Role = model.Role,
                        Email = model.Email
                    };

                    if(model.Role == "admin")
                    {
                        IdentityRole adminRole = await roleManager.FindByNameAsync("admin");
                        await userManager.AddToRoleAsync(user, adminRole.Name);
                    }
                    else if(model.Role == "culam")
                    {
                        IdentityRole culAmRole = await roleManager.FindByNameAsync("culam");
                        await userManager.AddToRoleAsync(user, culAmRole.Name);
                    }

                    context.Employees.Add(employee);
                    context.SaveChanges();

                    TempData["message"] = "Added Employee " + employee.FName + " " + employee.LName;

                    return View("Register");
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var employee = context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
            TempData["message"] = "Employee " + employee.FName + " " + employee.LName + " Deleted.";
            return View("Search");
        }

        [HttpGet]
        public IActionResult Search()
        {
            UserSearchViewModel vm = new UserSearchViewModel()
            {
                Results = new List<Employee>()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(UserSearchViewModel vm)
        {
            vm.Results = context.Employees.ToList();

            if (!string.IsNullOrEmpty(vm.Term))
            {
                string searchText = vm.Term.ToLower();
                vm.Results = vm.Results.Where(item => item.FName.ToLower().Contains(searchText) 
                || item.LName.ToLower().Contains(searchText)
                || item.Email.ToLower().Contains(searchText)).ToList();
            }

            if (vm.Branch != "Any")
            {
                vm.Results = vm.Results.Where(item => item.Branch.Contains(vm.Branch)).ToList();
            }

            if (vm.Role != "Any")
            {
                vm.Results = vm.Results.Where(item => item.Role.Contains(vm.Role)).ToList();
            }

            return View(vm);
        }
    }
}
