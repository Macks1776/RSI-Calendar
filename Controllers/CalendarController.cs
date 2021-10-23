using Microsoft.AspNetCore.Mvc;
using RSI_Calendar.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RSI_Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private CalendarContext context { get; set; }

        public CalendarController(CalendarContext ctx) => context = ctx;

        public IActionResult Calendar()
        {
            return View("Calendar");
        }

        public IActionResult Day()
        {
            return View("Day");
        }

        public IActionResult Schedule()
        {
            return View("Schedule");
        }

        public string GetCalendarData()
        {
            var events = context.Events.ToList();
            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach(var data in events)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate);
                eventList.Add(calevent);
            }

            string json = JsonConvert.SerializeObject(eventList);

            return json;
        }
        
    }
}


