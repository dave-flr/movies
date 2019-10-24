using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;
using movies.ViewModels;

namespace movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _db;

        public MovieController(MoviesDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View("Movie");
        }
    }
}