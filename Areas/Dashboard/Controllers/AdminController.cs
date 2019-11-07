using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace movies.Areas.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        [Area("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Dashboard")]
        public IActionResult Table()
        {
            return View();
        }
    }
}