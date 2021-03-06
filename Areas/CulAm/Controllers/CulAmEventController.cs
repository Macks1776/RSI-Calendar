using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using RSI_Calendar.Models;
using Attachment = RSI_Calendar.Models.Attachment; //SendGrid has a class called 'Attachment' that isn't used, but this using statment makes it so that when we type attachment it knows we mean our attachment

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
                TempData["id"] += attachment.ID + ",";
            }

            TempData["EventID"] = id;

            return View(tableEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Event tableEvent)
        {
            if (ModelState.IsValid)
            {
                if (tableEvent.EventID == 0)
                {
                    if (tableEvent.Type == "Req")
                    {
                        string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                        var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch).ToList();

                        foreach (var e in employees)
                        {
                            string fullName = e.FName + " " + e.LName;
                            await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Required", "Add", link);
                        }
                    }
                    else if (tableEvent.Type == "Edu")
                    {
                        string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                        var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveEduNotis == true);

                        foreach (var e in employees)
                        {
                            string fullName = e.FName + " " + e.LName;
                            await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Educational", "Add", link);
                        }
                    }
                    else if (tableEvent.Type == "Fam")
                    {
                        string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                        var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveFamNotis == true);

                        foreach (var e in employees)
                        {
                            string fullName = e.FName + " " + e.LName;
                            await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Fun w/ Family", "Add", link);
                        }
                    }
                    else if (tableEvent.Type == "Fun")
                    {
                        string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                        var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveFunNotis == true);

                        foreach (var e in employees)
                        {
                            string fullName = e.FName + " " + e.LName;
                            await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Fun w/ Co-Workers", "Add", link);
                        }
                    }

                    context.Events.Add(tableEvent);
                }
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
        public async Task<LocalRedirectResult> Delete()
        {
            var tableEvent = context.Events.Find(TempData["id"]);
            var attachments = context.Attachments.Where(a => a.EventID == tableEvent.EventID).ToList();
            foreach(var a in attachments)
            {
                context.Attachments.Remove(a);
            }
            context.Events.Remove(tableEvent);

            if (tableEvent.Type == "Req")
            {
                string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch).ToList();

                foreach (var e in employees)
                {
                    string fullName = e.FName + " " + e.LName;
                    await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Required", "Delete");
                }
            }
            else if (tableEvent.Type == "Edu")
            {
                string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveEduNotis == true);

                foreach (var e in employees)
                {
                    string fullName = e.FName + " " + e.LName;
                    await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Educational", "Delete");
                }
            }
            else if (tableEvent.Type == "Fam")
            {
                string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveFamNotis == true);

                foreach (var e in employees)
                {
                    string fullName = e.FName + " " + e.LName;
                    await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Fun w/ Family", "Delete");
                }
            }
            else if (tableEvent.Type == "Fun")
            {
                string link = "https://localhost:5001/event/details/" + tableEvent.EventID.ToString();

                var employees = context.Employees.Where(e => e.Branch == tableEvent.Branch && e.ReceiveFunNotis == true);

                foreach (var e in employees)
                {
                    string fullName = e.FName + " " + e.LName;
                    await EventNotificationEmail(e.Email, fullName, tableEvent.Name, "Fun w/ Co-Workers", "Delete");
                }
            }

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
                    Title = tableEvent.AttachmentTitle,
                    Link = tableEvent.AttachmentLink
                };

                context.Attachments.Add(attachment);

                context.SaveChanges();
                string returnURL = "/culam/culamevent/edit/" + tableEvent.EventID;
                return LocalRedirect(returnURL);
            }
            else
            {
                string returnURL = "/culam/culamevent/edit/" + tableEvent.EventID;
                return LocalRedirect(returnURL);
            }
        }

        [HttpGet]
        public IActionResult EditAttachment(int id)
        {
            var attachment = context.Attachments.Find(id);
            return View(attachment);
        }

        [HttpPost]
        public IActionResult EditAttachment(Attachment attachment)
        {
            var editedAttachment = context.Attachments.Find(attachment.ID);

            editedAttachment.Link = attachment.Link;
            editedAttachment.Title = attachment.Title;
            context.Attachments.Update(editedAttachment);
            context.SaveChanges();

            return LocalRedirect("/culam/culamevent/edit/" + attachment.EventID);
        }

        [HttpGet]
        public IActionResult DeleteAttachment(int id)
        {
            var attachment = context.Attachments.Find(id);
            return View(attachment);
        }

        [HttpPost]
        public IActionResult DeleteAttachment(Attachment attachment)
        {
            context.Attachments.Remove(attachment);
            context.SaveChanges();
            return LocalRedirect("/culam/culamevent/edit/" + attachment.EventID);
        }

        public IActionResult ManageAttachments(int id)
        {
            var attachments = context.Attachments.Where(a => a.EventID == id).ToList();
            return View(attachments);
        }

        //Method for sending emails using SendGrid link is an optional paramater since you don't have a link for deleted events
        static async Task EventNotificationEmail(string email, string fullName, string eventName, string eventType, string function, string link = "nolink")
        {
            //Removed the key for the api to make SendGrid happy. Contact me and I will give you the key and the instructions on how to use it
            //Without it app works just fine, just won't be able to send emails.
            var key = "key"; // not the properplace to store it, but I couldn't get the enviorment vairiable to work
            var client = new SendGridClient(key);
            var from = new EmailAddress("testcalender177@gmail.com", "Test McTest");
            string subject;

            if(function.ToUpper() == "ADD")
                subject = $"New {eventType} Event: {eventName}";
            else
                subject = $"New {eventType} Event: {eventName}";

            var to = new EmailAddress(email, fullName);
            string plainTextContent;

            if(function.ToUpper() == "ADD")
                plainTextContent = $"RSI Cultrual Event Calendar Notification: New {eventType} Event {eventName}";
            else
                plainTextContent = $"RSI Cultrual Event Calendar Notification: Deleted {eventType} Event: {eventName}";

            string htmlContent;
            if(function.ToUpper() == "ADD")
                htmlContent = $"RSI Cultrual Event Calendar Notification: New {eventType} Event <em><a href='{link}'>{eventName}</a></em>.";
            else
                htmlContent = $"RSI Cultrual Event Calendar Notification: Deleted {eventType} Event <em>>{eventName}</em>.";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
