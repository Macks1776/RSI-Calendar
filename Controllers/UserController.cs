using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RSI_Calendar.Models;
using RSI_Calendar.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;

namespace RSI_Calendar.Controllers
{
    public class UserController : Controller
    {
        private CalendarContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(UserManager<User> userMgr, SignInManager<User> signInMgr, CalendarContext ctx)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            context = ctx;
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Calendar", "Calendar");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await userManager.GetUserAsync(User);
            if(user != null)
            {
                string userEmail = user.Email.ToString();
                var employeeList = context.Employees.Where(e => e.Email == userEmail).ToList();
                Employee employee = employeeList[0];

                return View(employee);
            }

            return View("Calendar");
        }

        [HttpPost]
        public IActionResult Settings(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Update(employee);
                context.SaveChanges();
                TempData["message"] = "Changes saved.";
                return View("Settings");
            }

            TempData["message"] = "There was a problem.\nNo changes saved.";
            return View("Settings");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(Employee employee)
        {
            if(ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(employee.Email);

                if(user != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, employee.OldPassword, employee.NewPassword);

                    if(result.Succeeded)
                    {
                        context.Employees.Update(employee);
                        TempData["message"] = "Changes Saved";
                        return RedirectToAction("Settings");
                    }
                }             
            }
            else
            {
                TempData["message"] = "There was a problem changing your password. \nPassword was NOT changed.";
                return RedirectToAction("Settings");
            }

            return RedirectToAction("Settings");
        }

        public async Task<IActionResult> SendTestEmail()
        {
            var key = "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";
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            var subject = "Test Email";
            var to = new EmailAddress("maxswann1995@gmail.com", "Max Swann");
            var plainTextContent = "this was a test email. this isn't too hard to do I think";
            var htmlContent = "<strong>and easy to do possibly</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return RedirectToAction("Settings");
        }
    }
}
