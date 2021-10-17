﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RSI_Calendar.Areas.Admin.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(255)]
        public string fName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(255)]
        public string lName { get; set; }

        [Required(ErrorMessage = "Select Location")]
        [StringLength(255)]
        public string location { get; set; }

        [Required(ErrorMessage = "Select Role")]
        [StringLength(255)]
        public string role { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
