using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using movies.Models;

namespace movies.Areas.Dashboard.ViewModels
{
    public class UserListTable
    {
        public IdentityUser Users { get; set; }
        public int CommentCount { get; set; }
    }
}