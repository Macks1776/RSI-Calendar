using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Areas.CulAm.Controllers
{
    public class EventController : Controller
    {
        [Area("CulAm")]
        public IActionResult Edit()
        {
            return View("Edit");
        }

        [Area("CulAm")]
        public IActionResult Delete()
        {
            return View("Delete");
        }
    }
}
