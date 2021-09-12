using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        public IActionResult Settings()
        {
            return View("Settings");
        }
    }
}
