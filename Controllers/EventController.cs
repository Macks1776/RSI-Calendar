using Microsoft.AspNetCore.Mvc;
using RSI_Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Controllers
{
    public class EventController : Controller
    {
        private CalendarContext context;

        public EventController(CalendarContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Details(int id = 1) //TODO: after this is connected to actual events, remove the default id
        {
            Event e = context.Events.Find(id);

            return View(e);
        }

        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
