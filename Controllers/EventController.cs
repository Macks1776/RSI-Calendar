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
            EventSearchViewModel vm = new EventSearchViewModel()
            {
                IncludeName = false,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                IncludeDate = false,
                Results = new List<Event>()
            };

            // Search View opens with a list of all future events ordered by startdate
            vm.Results = context.Events
                .Where(item => item.StartDate.Date >= DateTime.Today)
                .OrderBy(e => e.StartDate)
                .ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(EventSearchViewModel vm)
        {
            
            vm.Results = context.Events.ToList();

            if (vm.IncludeName && !string.IsNullOrEmpty(vm.Name))
            {
                vm.Results = vm.Results.Where(item => item.Name.ToLower().Contains(vm.Name.ToLower())).ToList();
            }

            if (vm.IncludeDate)
            {
                if (vm.StartDate != null && vm.StartDate.ToString() != "")
                {
                    vm.Results = vm.Results.Where(item => item.StartDate.Date >= vm.StartDate.Date).ToList();
                }

                if (vm.EndDate != null && vm.EndDate.ToString() != "")
                {
                    vm.Results = vm.Results.Where(item => item.StartDate.Date <= vm.EndDate.Date).ToList();
                }
            }
            else
            {
                vm.StartDate = DateTime.Today;
                vm.EndDate = DateTime.Today;
            }

            if (vm.Branch != "Any")
            {
                vm.Results = vm.Results.Where(item => item.Branch.Contains(vm.Branch)).ToList();
            }

            if(vm.Type != "Any")
            {
                vm.Results = vm.Results.Where(item => item.Type.Contains(vm.Type)).ToList();
            }

            return View(vm);
        }
    }
}
