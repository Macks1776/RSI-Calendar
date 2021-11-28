using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RSI_Calendar.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }


    }
}
