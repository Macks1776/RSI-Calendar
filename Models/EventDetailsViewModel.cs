using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Models
{
    public class EventDetailsViewModel
    {
        public Event Event { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
