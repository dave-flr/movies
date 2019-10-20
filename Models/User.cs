using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace movies.Models
{
    public class User
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public string UserName {get; set;}
    }
}