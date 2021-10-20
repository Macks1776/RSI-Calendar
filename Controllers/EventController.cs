using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSI_Calendar.Models;

namespace RSI_Calendar.Controllers
{
    public class EventController : Controller
    {
        private CalendarContext context;

        public EventController(CalendarContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Details(int id)
        {
            var eventView = context.Events.Find(id);
            return View(eventView);
        }

        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
