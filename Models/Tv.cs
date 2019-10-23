using System.Collections.Generic;

namespace movies.Models
{
    public class Tv
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Overview { get; set; }
        public int Rating { get; set; }
        public string ImagePath { get; set; }
        public List<Comment> Comments { get; set; }

        public Tv()
        {
            Comments = new List<Comment>();
        }
    }
}