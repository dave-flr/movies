using movies.Models;

namespace movies.Areas.Dashboard.ViewModels
{
    public class AdminViewModel
    {
        public int UserCount { get; set; }
        public int RolesCount { get; set; }
        public int MoviesCount { get; set; }
        public int CommentsCount { get; set; }
    }
}