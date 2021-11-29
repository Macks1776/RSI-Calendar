using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RSI_Calendar.Models;
using RSI_Calendar.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;
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
            if (user != null)
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
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(employee.Email);

                if (user != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, employee.OldPassword, employee.NewPassword);

                    if (result.Succeeded)
                    {
                        context.Employees.Update(employee);
                        TempData["message"] = "Changes Saved";
                        string fullName = employee.FName + " " + employee.LName;
                        await ChangedPasswordNotificationEmail(employee.Email, fullName);
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

        static async Task ChangedPasswordNotificationEmail(string email, string name)
        {
            var key = "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"; // not the properplace to store it, but I couldn't get the enviorment vairiable to work
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            var subject = "Password Change Notification";
            var to = new EmailAddress(email, name);
            var plainTextContent = "Your password has been reset. If this was not you, then contact your administator.";
            var htmlContent = "Your password has been reset. If this <em>was not you</em>, then contact your administator.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    TempData["message"] = "The email provided did not belong to a register user. Please check your entry or contact your Admin.";
                    return View("ForgotPassword"); //This should probably go back to the forgot password page and show a message saying user not found.
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var link = Url.Action("ResetPassword", "User", new { Token = token, Email = user.Email }, Request.Scheme);

                string fullName = user.FirstName + " " + user.LastName;
                await PasswordResetEmail(user.Email, fullName, link);

                
                return View("ForgotPasswordConfirmation"); // View telling the user to check their email and follow the instructions.

            }
            else
            {
                TempData["message"] = "There was an error, please try again or contact your Admin.";
                return View("ForgotPassword"); // Return back to the forgot password view with what the errors are.
            }
        }

        static async Task PasswordResetEmail(string email, string fullName, string link)
        {
            var key = "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"; // not the properplace to store it, but I couldn't get the enviorment vairiable to work
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            var subject = "Password Change Notification";
            var to = new EmailAddress(email, fullName);
            var plainTextContent = $"You have requested to reset your password. Go to this link to reset your password {link}";
            var htmlContent = $"You have requested to reset your password. Go to this <a href={link}>Link</a> to reset your password.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
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


    }
}
