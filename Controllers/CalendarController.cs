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

        [HttpGet]
        public IActionResult Calendar()
        {
            var calendar = new CalendarViewModel();
            calendar.Branch = "default";
            TempData["CalendarBranch"] = calendar.Branch;
            return View("Calendar", calendar);
        }

        [HttpPost]
        public IActionResult ChangeBranch(CalendarViewModel calendar)
        {
            TempData["CalendarBranch"] = calendar.Branch;
            //var cal = new CalendarViewModel(calendar.Branch);
            return View("Calendar", calendar);
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

        public async Task<string> ReqEventJson()
        {
            string branch = TempData.Peek("CalendarBranch").ToString();
            List<Event> events = new List<Event>();

            if (branch.ToLower() == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employeeList = context.Employees.Where(e => e.Email == user.Email).ToList();
                events = context.Events.Where(e => e.Type == "Req" && e.Branch == employeeList[0].Branch).ToList();
            }
            else 
                events = context.Events.Where(e => e.Type == "Req" && e.Branch == branch).ToList();

            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach (var e in events)
            {
                CalendarEvent calEvent = new CalendarEvent(e.EventID, e.Name, e.StartDate, e.EndDate, e.Description, e.Type);
                eventList.Add(calEvent);
            }

            string jsonEvents = JsonConvert.SerializeObject(eventList);

            return jsonEvents;
        }

        public async Task<string> EduEventJson()
        {
            string branch = TempData.Peek("CalendarBranch").ToString();
            List<Event> events = new List<Event>();

            if (branch.ToLower() == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employeeList = context.Employees.Where(e => e.Email == user.Email).ToList();
                events = context.Events.Where(e => e.Type == "Edu" && e.Branch == employeeList[0].Branch).ToList();
            }
            else
                events = context.Events.Where(e => e.Type == "Edu" && e.Branch == branch).ToList();

            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach (var e in events)
            {
                CalendarEvent calEvent = new CalendarEvent(e.EventID, e.Name, e.StartDate, e.EndDate, e.Description, e.Type);
                eventList.Add(calEvent);
            }

            string jsonEvents = JsonConvert.SerializeObject(eventList);

            return jsonEvents;
        }

        public async Task<string> FunEventJson()
        {
            string branch = TempData.Peek("CalendarBranch").ToString();
            List<Event> events = new List<Event>();

            if (branch.ToLower() == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employeeList = context.Employees.Where(e => e.Email == user.Email).ToList();
                events = context.Events.Where(e => e.Type == "Fun" && e.Branch == employeeList[0].Branch).ToList();
            }
            else
                events = context.Events.Where(e => e.Type == "Fun" && e.Branch == branch).ToList();

            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach (var e in events)
            {
                CalendarEvent calEvent = new CalendarEvent(e.EventID, e.Name, e.StartDate, e.EndDate, e.Description, e.Type);
                eventList.Add(calEvent);
            }

            string jsonEvents = JsonConvert.SerializeObject(eventList);

            return jsonEvents;
        }

        public async Task<string> FamEventJson()
        {
            string branch = TempData.Peek("CalendarBranch").ToString();
            List<Event> events = new List<Event>();

            if (branch.ToLower() == "default")
            {
                var user = await userManager.GetUserAsync(User);
                var employeeList = context.Employees.Where(e => e.Email == user.Email).ToList();
                events = context.Events.Where(e => e.Type == "Fam" && e.Branch == employeeList[0].Branch).ToList();
            }
            else
                events = context.Events.Where(e => e.Type == "Fam" && e.Branch == branch).ToList();

            List<CalendarEvent> eventList = new List<CalendarEvent>();

            foreach (var e in events)
            {
                CalendarEvent calEvent = new CalendarEvent(e.EventID, e.Name, e.StartDate, e.EndDate, e.Description, e.Type);
                eventList.Add(calEvent);
            }

            string jsonEvents = JsonConvert.SerializeObject(eventList);

            return jsonEvents;
        }

    }
}


