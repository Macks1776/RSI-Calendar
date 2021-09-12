using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Details()
        {
            return View("Details");
        }

        public IActionResult Search()
        {
            return View("Details");
        }
    }
}
