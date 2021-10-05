using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Areas.CulAm.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Edit()
        {
            return View("Edit");
        }

        public IActionResult Delete()
        {
            return View("Delete");
        }
    }
}
