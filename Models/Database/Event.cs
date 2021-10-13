using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace RSI_Calendar.Models
{
    public class Event
    {
        public int EventID { get; set; } // Primary Key

        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Date { get; set; } // I made Date and Time strings because the input from the user will be string based
        public string Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
