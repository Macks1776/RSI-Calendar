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
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description);
                eventList.Add(calevent);
            }

            string json = JsonConvert.SerializeObject(eventList);

            return json;
        }

        public string GetRequiredEvents()
        {
            var requiredEvents = context.Events.Where(e => e.Type == "Req").ToList();
            List<CalendarEvent> requiredEventList = new List<CalendarEvent>();

            foreach (var data in requiredEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description);
                requiredEventList.Add(calevent);
            }

            string jsonRequiredEvents = JsonConvert.SerializeObject(requiredEventList);

            return jsonRequiredEvents;
        }

        public string GetEducationEvents()
        {
            var educationEvents = context.Events.Where(e => e.Type == "Edu").ToList();
            List<CalendarEvent> educationEventList = new List<CalendarEvent>();

            foreach (var data in educationEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description);
                educationEventList.Add(calevent);
            }

            string jsonEducationEvents = JsonConvert.SerializeObject(educationEventList);

            return jsonEducationEvents;
        }

        public string GetFamilyEvents()
        {
            var familyEvents = context.Events.Where(e => e.Type == "Fam").ToList();
            List<CalendarEvent> familyEventList = new List<CalendarEvent>();

            foreach (var data in familyEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description);
                familyEventList.Add(calevent);
            }

            string jsonFamilyEvents = JsonConvert.SerializeObject(familyEventList);

            return jsonFamilyEvents;
        }

        public string GetFunEvents()
        {
            var funEvents = context.Events.Where(e => e.Type == "Fun").ToList();
            List<CalendarEvent> funEventList = new List<CalendarEvent>();

            foreach (var data in funEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description);
                funEventList.Add(calevent);
            }

            string jsonFamilyEvents = JsonConvert.SerializeObject(funEventList);

            return jsonFamilyEvents;
        }
        
    }
}


