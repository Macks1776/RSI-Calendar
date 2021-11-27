using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSI_Calendar.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Branch { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
