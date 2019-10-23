using System.Collections.Generic;
using movies.Models;

namespace movies.ViewModels
{
    public class HomeModel
    {
        public List<Movie> CarouselMovies { get; set; }
        public List<Movie> ListMovies { get; set; }
        public List<Comment> LastComments { get; set; }
    }
}