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
            EventSearchViewModel vm = new EventSearchViewModel()
            {
                Results = new List<Event>()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(string name, DateTime start, DateTime end, string branch, string type)
        {
            EventSearchViewModel vm = new EventSearchViewModel()
            {
                Results = context.Events.ToList()
            };

            if (!string.IsNullOrEmpty(name))
            {
                vm.Results = (List<Event>)vm.Results.Where(item => item.Name.Contains(name));
            }

            return View(vm);
        }
    }
}
