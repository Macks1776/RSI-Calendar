using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace RSI_Calendar.Models
{
    public class Event
    {
        public int EventID { get; set; } // Primary Key

        [Required(ErrorMessage = "Please Enter Event Name")]
        public string Name { get; set; }

        public string Type { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        // Fields not included in the databse but needed for adding Attachments
        [NotMapped]
        public string AttachmentTitle { get; set; }
        
        // The NotMapped attribute will keep these fields from being put into the database but still let them be used by the class
        [NotMapped]
        public string AttachmentName { get; set; }

        [NotMapped]
        public string AttachmentLink { get; set; }

    }
}
