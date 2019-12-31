using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRF.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRF.Data;
using MRF.Data.Repository.Implementations;
using MRF.Data.Repository.Interfaces;
using MRF.Models;
using MRF.Services;
using MRF.Services.Domain;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder;
using MRF.Web.ViewModelBinder.Interfaces;

namespace MRF.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryViewModelBinder, InventoryViewModelBinder>();
            services.AddScoped<IInventoryIndexViewModelBinder, InventoryIndexViewModelBinder>();

            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExpenseViewModelBinder, ExpenseViewModelBinder>();
            services.AddScoped<IExpenseIndexViewModelBinder, ExpenseIndexViewModelBinder>();

            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleViewModelBinder, SaleViewModelBinder>();
            services.AddScoped<ISaleIndexViewModelBinder, SaleIndexViewModelBinder>();

            services.AddScoped<IProductionService, ProductionService>();
            services.AddScoped<IProductionViewModelBinder, ProductionViewModelBinder>();
            services.AddScoped<IProductionIndexViewModelBinder, ProductionIndexViewModelBinder>();

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(opt => { opt.LoginPath = "/Identity/Account/Login"; });
            //services.AddAuthorization(opt =>
            //{
            //    opt.DefaultPolicy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
            //        .RequireAuthenticatedUser()
            //        .Build();
            //});
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
