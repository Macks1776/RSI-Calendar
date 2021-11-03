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
            var thisEvent = context.Events.Find(id);
            var attachments = context.Attachments.Where(a => a.EventID == id);

            foreach (var attachment in attachments)
            {
                TempData["titles"] += attachment.Title + ",";
                TempData["links"] += attachment.Link + ",";
            }

            return View(thisEvent);
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
