using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace movies.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int TvId { get; set; }
        public Tv Tv { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}