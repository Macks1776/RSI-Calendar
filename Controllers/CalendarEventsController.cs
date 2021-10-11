using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSI_Calendar.Models;

namespace RSI_Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventsController : Controller
    {
        private readonly CalendarContext context;

        public CalendarEventsController(CalendarContext ctx) => context = ctx;

        // GET: api/CalendarEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await context.Events
                .Where(e => !((e.End <= start) || (e.Start >= end)))
                .ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> PutCalendarEvent(int id)
        {
            var calendarEvent = await context.Events.FindAsync(id);

            if (calendarEvent == null)
                return NotFound();

            return calendarEvent;
        }

        //PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarEvent(int id, Event calendarEvent)
        {
            if (id != calendarEvent.EventID)
                return BadRequest();

            context.Entry(calendarEvent).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                if (!CalendarEventExists(id))
                    return NotFound();
                else
                    throw;

            }

            return NoContent();
        }

        //Post: api/Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostCalendarEvent(Event calendarEvent)
        {
            context.Events.Add(calendarEvent);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarEvent", new { id = calendarEvent.EventID }, calendarEvent);
        }

        //Delete: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarEvent(int id)
        {
            var calendarEvent = await context.Events.FindAsync(id);
            if (calendarEvent == null)
                return NotFound();

            context.Events.Remove(calendarEvent);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarEventExists(int id)
        {
            return context.Events.Any(e => e.EventID == id);
        }

        
    }


}
