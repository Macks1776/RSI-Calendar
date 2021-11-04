using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSI_Calendar.Models;

namespace RSI_Calendar.Areas.CulAm.Controllers
{
    [Area("CulAm")]
    public class CulAmEventController : Controller
    {
        private CalendarContext context { get; set; }

        public CulAmEventController(CalendarContext ctx) => context = ctx; //constructor for the controller passing the calendar context (database) to the controller

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Event());
        }

        // "event" is a resevered word so that's why I am using tableEvent and thisEvent

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var tableEvent = context.Events.Find(id);
            return View(tableEvent);
        }

        [HttpPost]
        public IActionResult Edit(Event thisEvent)
        {
            if (ModelState.IsValid)
            {
                if (thisEvent.EventID == 0)
                    context.Events.Add(thisEvent);
                else
                    context.Events.Update(thisEvent);

                context.SaveChanges();
                return LocalRedirect("/calendar/calendar");
            }
            else
            {
                ViewBag.Action = (thisEvent.EventID == 0) ? "Add" : "Edit"; // Tertiary statement => "if event id==0 then ViewBag.Action = "Add" else ViewBag.Action = "Edit"
                return View(thisEvent);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var thisEvent = context.Events.Find(id);
            var attachments = context.Attachments.Where(a => a.EventID == id).ToList();
            
            foreach(var attachment in attachments)
            {
                TempData["titles"] += attachment.Title + ",";
                TempData["links"] += attachment.Link + ",";
            }

            TempData["id"] = id;
            return View(thisEvent);
        }

        [HttpPost]
        public LocalRedirectResult Delete()
        {
            var thisEvent = context.Events.Find(TempData["id"]);
            context.Events.Remove(thisEvent);
            context.SaveChanges();
            return LocalRedirect("/calendar/calendar");
        }
    }
}
