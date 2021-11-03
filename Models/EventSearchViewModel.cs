using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Models
{
    public class EventSearchViewModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public string Branch { get; set; }
        public List<Event> Results { get; set; }
    }
}
