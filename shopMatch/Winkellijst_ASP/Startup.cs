using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Winkellijst_ASP.Areas.Identity.Data;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Helpers;
using Winkellijst_ASP.Services;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.Validators;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation();
            services.AddTransient<IValidator<WinkelLijst>, WinkelLijstValidator>();
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddTransient<IValidator<ProductViewModel>, ProductViewModelValidator>();
            services.AddTransient<IValidator<WinkellijstCreateViewModel>, WinkellijstCreateViewModelValidator>();
            services.AddTransient<IValidator<WinkellijstEditViewModel>, WinkellijstEditViewModelValidator>();
            services.AddDbContext<GebruikerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GebruikerConnection")));
            services.AddDefaultIdentity<AppGebruiker>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<GebruikerContext>();
            services.AddMvc().AddRazorPagesOptions(options => {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.RequireUniqueEmail = true;
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Add DI for email service
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "alternative",
                    pattern: "{controller=AddProducts}/{id?}/{action=Index}");

                endpoints.MapRazorPages();
            });
        }
    }
}
