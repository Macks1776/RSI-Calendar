using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Edit()
        {
            return View("Edit");
        }

        public IActionResult Delete()
        {
            return View("Delete");
        }

        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
