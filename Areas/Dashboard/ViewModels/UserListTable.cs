using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace movies.Areas.Dashboard.ViewModels
{
    public class UserListTable
    {
        public IdentityUser Users { get; set; }
        public int CommentCount { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}