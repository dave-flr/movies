using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using movies.Models;
using movies.Areas.Dashboard.ViewModels;

namespace movies.Areas.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MoviesDbContext _db;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            MoviesDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        [Area("Dashboard")]
        [Authorize(Roles = "Admin, Editors")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Dashboard")]
        [Authorize(Roles = "Admin, Editors")]
        public async Task<IActionResult> Users()
        {
            var userListTables = new List<UserListTable>();
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                var userListTableModel = new UserListTable
                {
                    Users = user,
                    CommentCount = await _db.Comments
                        .CountAsync(u => u.UserId == user.Id)
                };
                userListTables.Add(userListTableModel);
            }

            return View("Users", userListTables);
        }
    }
}