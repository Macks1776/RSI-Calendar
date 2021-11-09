using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Areas.Admin.Models
{
    public class UserSearchViewModel
    {
        public string Term { get; set; }
        public string Branch { get; set; }
        public string Role { get; set; }
        public List<RSI_Calendar.Models.Employee> Results { get; set; }
    }
}
