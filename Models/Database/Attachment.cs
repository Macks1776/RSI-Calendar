using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RSI_Calendar.Models
{
    public class Attachment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Attachment must be attached to an event.")]
        public int EventID { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }
    }
}
