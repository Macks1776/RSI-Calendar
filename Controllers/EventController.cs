using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet]
        public IActionResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ActionResult getEvents(string nameParam, DateTime dateParam, string branchParam, string typeParam)
        {
            IList<Event> results = new List<Event>();

            

            return View(results);
        }
    }
}
