using System.Collections.Generic;
using movies.Models;

namespace movies.ViewModels
{
    public class HomeModel
    {
        public List<Movies> CarouselMovies { get; set; }
        public List<Movies> ListMovies { get; set; }
        public List<Comment> LastComments { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}