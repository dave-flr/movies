using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movies.Models;
using movies.ViewModels;

namespace movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly movies_db_Context _db;

        public HomeController(movies_db_Context db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var homeModel = new HomeModel
            {
                CarouselMovies = await _db.Movies.ToListAsync(),
                ListMovies = await _db.Movies.ToListAsync(),
                LastComments = await _db.Comments.ToListAsync()
            };
            return View(homeModel);
        }
    }
}