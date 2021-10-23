using Microsoft.AspNetCore.Mvc;
using RSI_Calendar.Models;
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
            EventDetailsViewModel vm = new EventDetailsViewModel()
            {
                Event = context.Events.Find(id),
                Attachments = (List<Attachment>)context.Attachments.Where(a => a.EventID == id).ToList()
            };

            return View(vm);
        }

        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
