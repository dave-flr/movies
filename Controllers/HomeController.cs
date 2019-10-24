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
        private readonly MoviesDbContext _db;

        public HomeController(MoviesDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int moviesPerPage = 50;
            var listMovies = await _db.Movies.OrderBy(x => x.Id)
                .Skip((page - 1) * moviesPerPage)
                .Take(moviesPerPage).ToListAsync();
            var totalMovies = _db.Movies.Count();
            var homeModel = new HomeModel
            {
                ListMovies = listMovies,
                CarouselMovies = await _db.Movies.ToListAsync(),
                LastComments = await _db.Comments.Include(user => user.User).ToListAsync(),
                PaginationModel = new PaginationModel(page, totalMovies, moviesPerPage)
            };
            return View(homeModel);
        }

        public async Task<IActionResult> SearchMovie(string query)
        {
            query = "%" + query + "%";
            var moviesResult = await _db.Movies
                .Where(q => EF.Functions.Like(q.Title, query)).ToListAsync();
            return Json(moviesResult);
        }
    }
}