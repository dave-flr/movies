using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;

namespace movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _db;

        public MovieController(MoviesDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Id(int? id) //Show a Movie
        {
            if (id == null) return NotFound();
            var movie = await FindMovie(id);
            return View("Movie", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Comment(Comment comment)
        {
            if (!ModelState.IsValid) return NotFound();

            comment.Date = DateTime.Now.ToString("d"); //Save the current date

            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync(); 
            
            var movie = await FindMovie(comment.MoviesId);

            movie.Rating = movie.Comments.Sum(rt => rt.Rating) / movie.Comments.Count; //Update the rating with every comment

            await _db.SaveChangesAsync();
            return View("Movie", movie);
        }

        private async Task<Movies> FindMovie(int? id) //Find a movie with the given id
        {
            return await _db.Movies
                .Where(c => c.Id == id)
                .Include(c => c.Comments)
                .ThenInclude(user => user.User)
                .FirstOrDefaultAsync();
        }
    }
}