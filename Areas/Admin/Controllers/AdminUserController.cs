using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RSI_Calendar.Models;
using RSI_Calendar.Areas.Admin.Models;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;

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
                        Email = model.Email,
                        ReceiveEduNotis = true,
                        ReceiveFamNotis = true,
                        ReceiveFunNotis = true
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

                    string fullName = model.FName + " " + model.LName;

                    await SendNewAcctEmail(model.Email, fullName, model.Password);

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
        public async Task<IActionResult> Delete(Employee employee)
        {
            // Deleting the Employee
            context.Employees.Remove(employee);

            // Deleting the Log In Credtitials
            User deletedUser = await userManager.FindByEmailAsync(employee.Email);
            if(deletedUser != null)
            {
                IdentityResult result = await userManager.DeleteAsync(deletedUser);
                if (result.Succeeded)
                {
                    context.SaveChanges();
                    TempData["message"] = "Employee " + employee.FName + " " + employee.LName + " Deleted.";
                    return LocalRedirect("/calendar/calendar");
                }
                else
                    return View(employee);
            }
            else
                return View(employee);
        }

        [HttpGet]
        public IActionResult Search()
        {
            UserSearchViewModel vm = new UserSearchViewModel()
            {
                Results = new List<Employee>()
            };

            // Search view opens with list of Employees ordered by Last Name
            vm.Results = context.Employees
                .OrderBy(e => e.LName)
                .ToList();

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

        public async Task<IActionResult> RequestResetPassword(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(employee.Email);
                if (user == null)
                {
                    TempData["message"] = "The email provided did not belong to a register user.";
                    return View("Edit", employee); //This should probably go back to the forgot password page and show a message saying user not found.
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var link = Url.Action("ResetPassword", "User", new { Token = token, Email = user.Email }, Request.Scheme);

                string fullName = user.FirstName + " " + user.LastName;
                await PasswordResetEmail(user.Email, fullName, link);

                TempData["message"] = $"Password reset email sent to {user.Email}";
                return View("Edit", employee);

            }
            else
            {
                TempData["message"] = "There was an error.";
                return View("Edit", employee); // Return back to the forgot password view with what the errors are.
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetPassword.Email);
                if (user == null)
                {
                    TempData["message"] = "The email provided did not belong to a register user. Please check your entry or contact your Admin.";
                    return View("ForgotPassword"); // return a view saying that the user doesn't exist
                }

                var restPassResult = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

                if (!restPassResult.Succeeded)
                {
                    TempData["message"] = "There was an error. Please try again or contact your Admin.";
                    return View("ForgotPassword"); // Return a view saying that there was an error
                }

                return View("ResetPasswordConfirmation");
            }
            else
            {
                TempData["message"] = "There was an error. Please try again or contact your Admin.";
                return View("ForgotPassword"); // Return a view saying that there was an error
            }
        }

        static async Task PasswordResetEmail(string email, string fullName, string link)
        {
            var key = "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"; // not the properplace to store it, but I couldn't get the enviorment vairiable to work
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            var subject = "Admin Password Reset Request";
            var to = new EmailAddress(email, fullName);
            var plainTextContent = $"Your Admin has requested to reset your password. Go to this link to reset your password, {link}";
            var htmlContent = $"Your Admin has requested to reset your password. Go to this <a href={link}>Link</a> to reset your password.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        static async Task SendNewAcctEmail(string toEmail, string toName, string tempPassword)
        {
            var key = "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"; //Need to store this differently but I can't get it to access right via powershell
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            var subject = "New Account Information";
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = $"Welcome to Rural Sourcing! Below is your log in information for our Cultural Calendar.</br>User Name: {toEmail}\n\tPassword: {tempPassword}\n\nPlease login and change your password as soon as possible.\nClick the link to log in https://localhost:5001/user/login";
            var htmlContent = $"<strong>Welcome to Rural Sourcing!</strong> This is your login information for our <em>Cultural Calendar</em> User Name: {toEmail}   Password: {tempPassword}  Please login and change your password as soon as possible. Click <a href='https://localhost:5001/user/login'>Log In</a> to get started.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
