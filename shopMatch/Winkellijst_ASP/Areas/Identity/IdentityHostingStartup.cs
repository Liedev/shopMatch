using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Winkellijst_ASP.Areas.Identity.Data;
using Winkellijst_ASP.Data;

[assembly: HostingStartup(typeof(Winkellijst_ASP.Areas.Identity.IdentityHostingStartup))]
namespace Winkellijst_ASP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            
        }
    }
}