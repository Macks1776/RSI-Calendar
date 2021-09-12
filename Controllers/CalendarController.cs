using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Controllers
{
    public class CalendarController : Controller
    {

        public IActionResult Calendar()
        {
            return View("Calendar");
        }

        public IActionResult Day()
        {
            return View("Day");
        }
        
        public IActionResult MonthList()
        {
            return View("MonthList");
        }

    }
}
