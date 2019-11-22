using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;
using movies.ViewModels;

namespace movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public MovieController(MoviesDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Id(int? id, int? rating, string description = null) //Show a Movie
        {
            if (id == null) return NotFound();
            var dataPass = HttpContext.Session.GetString("TitleM");
            ViewData["TitleM"] = dataPass;
            ViewData["rating"] = rating;
            ViewData["description"] = description;
            var movie = await FindMovie(id);
            return View("Movie", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Comment(Comment comment, string returnMovieUrl = null)
        {
            if (!ModelState.IsValid) return NotFound();
            returnMovieUrl ??= Url.Content("~/"); //local redirect

            //Validate user id:
            var user = await _userManager.GetUserAsync(User);
            if (user.Id != comment.UserId) return NotFound();

            //Add the comment
            comment.Date = DateTime.Now.ToString("d"); //Save the current date
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            //Update the rating
            var movie = await FindMovie(comment.MoviesId);
            movie.Rating =
                movie.Comments.Sum(rt => rt.Rating) / movie.Comments.Count; //Update the rating with every comment
            await _db.SaveChangesAsync();

            return LocalRedirect(returnMovieUrl);
        }

        private async Task<Movies> FindMovie(int? id) //Find a movie with the given id
        {
            return await _db.Movies
                .Where(c => c.Id == id)
                .Include(c => c.Comments)
                .ThenInclude(user => user.User)
                .FirstOrDefaultAsync();
        }

        public async Task<IActionResult> AddToCart(int? id, string title = null)
        {
            if (title != null)
            {
                if (id == null) return NotFound();

                HttpContext.Session.SetString("TitleM", title);
                var titles = new ShoppingCart();
                titles.Titles.Add(title);

                var dataPass = HttpContext.Session.GetString("TitleM");
                ViewData["TitleM"] = dataPass;
                
                var movie = await FindMovie(id);
                return View("Movie", movie);
            }
            return NotFound();
        }
    }
}