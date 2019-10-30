using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movies.Models;

//using movies.Areas.Identity.Data;

[assembly: HostingStartup(typeof(movies.Areas.Identity.IdentityHostingStartup))]
namespace movies.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MoviesDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("AppDBContextString")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<MoviesDbContext>();
            });
        }
    }
}