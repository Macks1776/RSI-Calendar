using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RSI_Calendar.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RSI_Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private CalendarContext context { get; set; }
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public CalendarController(UserManager<User> userMgr, SignInManager<User> signInMgr, CalendarContext ctx)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            context = ctx;
        }

        public IActionResult Calendar()
        {
            return View("Calendar");
        }

        public string GetCalendarData()
        {
            var events = context.Events.ToList();
            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach(var data in events)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description, data.Type);
                eventList.Add(calevent);
            }

            string json = JsonConvert.SerializeObject(eventList);

            return json;
        }

        public async Task<string> GetRequiredEvents(string branch = "default")
        {
            List<Event> requiredEvents;

            if(branch == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employee = context.Employees.Where(e => e.Email == user.Email).ToList();
                requiredEvents = context.Events.Where(e => e.Type == "Req" && e.Branch == employee[0].Branch).ToList();
            }
            else
                requiredEvents = context.Events.Where(e => e.Type == "Req" && e.Branch == branch).ToList();

            List<CalendarEvent> requiredEventList = new List<CalendarEvent>();

            foreach (var data in requiredEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description, data.Type);
                requiredEventList.Add(calevent);
            }

            string jsonRequiredEvents = JsonConvert.SerializeObject(requiredEventList);

            return jsonRequiredEvents;
        }

        public async Task<string> GetEducationEvents(string branch = "default")
        {
            List<Event> educationEvents;

            if (branch == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employee = context.Employees.Where(e => e.Email == user.Email).ToList();
                educationEvents = context.Events.Where(e => e.Type == "Edu" && e.Branch == employee[0].Branch).ToList();
            }
            else
                educationEvents = context.Events.Where(e => e.Type == "Edu" && e.Branch == branch).ToList();
            List<CalendarEvent> educationEventList = new List<CalendarEvent>();

            foreach (var data in educationEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description, data.Type);
                educationEventList.Add(calevent);
            }

            string jsonEducationEvents = JsonConvert.SerializeObject(educationEventList);

            return jsonEducationEvents;
        }

        public async Task<string> GetFamilyEvents(string branch = "default")
        {
            List<Event> familyEvents;

            if (branch == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employee = context.Employees.Where(e => e.Email == user.Email).ToList();
                familyEvents = context.Events.Where(e => e.Type == "Fam" && e.Branch == employee[0].Branch).ToList();
            }
            else
                familyEvents = context.Events.Where(e => e.Type == "Fam" && e.Branch == branch).ToList();
            List<CalendarEvent> familyEventList = new List<CalendarEvent>();

            foreach (var data in familyEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description, data.Type);
                familyEventList.Add(calevent);
            }

            string jsonFamilyEvents = JsonConvert.SerializeObject(familyEventList);

            return jsonFamilyEvents;
        }

        public async Task<string> GetFunEvents(string branch = "default")
        {
            List<Event> funEvents;

            if (branch == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employee = context.Employees.Where(e => e.Email == user.Email).ToList();
                funEvents = context.Events.Where(e => e.Type == "Fun" && e.Branch == employee[0].Branch).ToList();
            }
            else
                funEvents = context.Events.Where(e => e.Type == "Fun" && e.Branch == branch).ToList();
            List<CalendarEvent> funEventList = new List<CalendarEvent>();

            foreach (var data in funEvents)
            {
                CalendarEvent calevent = new CalendarEvent(data.EventID, data.Name, data.StartDate, data.EndDate, data.Description, data.Type);
                funEventList.Add(calevent);
            }

            string jsonFamilyEvents = JsonConvert.SerializeObject(funEventList);

            return jsonFamilyEvents;
        }
        
    }
}


