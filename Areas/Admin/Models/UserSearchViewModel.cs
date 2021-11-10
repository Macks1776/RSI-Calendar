using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSI_Calendar.Models;

namespace RSI_Calendar.Areas.Admin.Models
{
    public class UserSearchViewModel
    {
        public string Term { get; set; }
        public string Branch { get; set; }
        public string Role { get; set; }
        public List<Employee> Results { get; set; }
    }
}
