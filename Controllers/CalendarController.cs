using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSI_Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace RSI_Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private CalendarContext context { get; set; }

        public CalendarController(CalendarContext ctx) => context = ctx;

        public IActionResult Month()
        {
            return View("Month");
        }

        public IActionResult Day()
        {
            return View("Day");
        }
        
        public IActionResult Schedule()
        {
            return View("Schedule");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await context.Events.Where(e => e.Date != null).ToListAsync();
        }

    }
}
