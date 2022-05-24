using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeDiningAdmin.Areas.Identity.Data;
using SafeDiningAdmin.Data;

[assembly: HostingStartup(typeof(SafeDiningAdmin.Areas.Identity.IdentityHostingStartup))]
namespace SafeDiningAdmin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SafeDiningAdminLoginContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SafeDiningAdminLoginContextConnection")));

                services.AddDefaultIdentity<SafeDiningAdminUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SafeDiningAdminLoginContext>();
            });
        }
    }
}