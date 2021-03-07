using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Svetaine.Areas.Identity.Data;
using Svetaine.Data;

[assembly: HostingStartup(typeof(Svetaine.Areas.Identity.IdentityHostingStartup))]
namespace Svetaine.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SvetaineContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SvetaineContextConnection")));

              //  services.AddDefaultIdentity<SvetaineUser>(options => options.SignIn.RequireConfirmedAccount = true)//uzkomentuoti, nes kitaip meta program.cs unhandled ecxeption
               //     .AddEntityFrameworkStores<SvetaineContext>();
            });
        }
    }
}