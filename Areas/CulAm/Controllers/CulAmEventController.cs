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
            var newEvent = new Event
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            };

            return View("Edit", newEvent);
        }

        // "event" is a resevered word so that's why I am using tableEvent and thisEvent

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var tableEvent = context.Events.Find(id);
            var attachments = context.Attachments.Where(a => a.EventID == id);

            foreach (var attachment in attachments)
            {
                TempData["titles"] += attachment.Title + ",";
                TempData["links"] += attachment.Link + ",";
            }

            return View(tableEvent);
        }

        [HttpPost]
        public IActionResult Edit(Event tableEvent)
        {
            if (ModelState.IsValid)
            {
                if (tableEvent.EventID == 0)
                    context.Events.Add(tableEvent);
                else
                    context.Events.Update(tableEvent);

                context.SaveChanges();
                return LocalRedirect("/calendar/calendar");
            }
            else
            {
                ViewBag.Action = (tableEvent.EventID == 0) ? "Add" : "Edit"; // Tertiary statement => "if event id==0 then ViewBag.Action = "Add" else ViewBag.Action = "Edit"
                return View(tableEvent);
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

        [HttpPost]
        public IActionResult AddAttachment(Event tableEvent)
        {
            if (ModelState.IsValid)
            {
                if (tableEvent.EventID == 0)
                    context.Events.Add(tableEvent);
                else
                    context.Events.Update(tableEvent);

                Attachment attachment = new Attachment
                {
                    EventID = tableEvent.EventID,
                    Title = tableEvent.AttachmentName,
                    Link = tableEvent.AttachmentLink
                };

                context.Attachments.Add(attachment);

                context.SaveChanges();
                string returnURL = "/culam/culamevent/edit/" + tableEvent.EventID;
                return LocalRedirect(returnURL);
            }
            else
            {
                string returnURL = "/culamevent/edit/" + tableEvent.EventID;
                return LocalRedirect(returnURL);
            }
        }

        [HttpGet]
        public IActionResult ManageAttachments(int id)
        {
            var attachments = context.Attachments.Where(a => a.EventID == id).ToList();
            return View(attachments);
        }
    }
}
