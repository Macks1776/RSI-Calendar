using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSI_Calendar.Models;

namespace RSI_Calendar.Controllers
{
    public class UserController : Controller
    {
        private CalendarContext context;

        public UserController(CalendarContext ctx)
        {
            context = ctx;
        }


        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpGet]
        public IActionResult Settings(int id = 1)
        {
            Employee employee = context.Employees.Find(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Settings()
        {
            return View("Settings");
        }
    }
}
