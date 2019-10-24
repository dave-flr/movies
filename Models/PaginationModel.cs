namespace movies.Models
{
    public class PaginationModel
    {
        public int ActualPage { get; set; }
        public int TotalMovies { get; set; }
        public int MoviesPerPage { get; set; }

        public PaginationModel(int actualPage, int totalMovies, int moviesPerPage)
        {
            ActualPage = actualPage;
            TotalMovies = totalMovies;
            MoviesPerPage = moviesPerPage;
        }
    }
}