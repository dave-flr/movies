using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using movies.Models;

namespace movies.ViewModels
{
    public class ShoppingCart
    {
        public List<Movies> MovieList { get; set; }
        public List<string> Titles {get;set;}

        public ShoppingCart()
        {
            MovieList = new List<Movies>();
            Titles = new List<string>();
        }
    }
}