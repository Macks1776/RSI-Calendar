using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        public IActionResult Edit()
        {
            return View("Edit");
        }

        [Area("Admin")]
        public IActionResult Delete()
        {
            return View("Delete");
        }

        [Area("Admin")]
        public IActionResult Search()
        {
            return View("Search");
        }
    }
}
