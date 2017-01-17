using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UniFIIcation.Models;
using UniFIIcation.Services;

namespace UniFIIcation
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _env = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<AnnouncementSeedData>();
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.User.RequireUniqueEmail = true;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<FIIContext>();

            //orar
            services.AddTransient<IMyParseWeb, ParseWeb>();
            //---------

            services.AddDbContext<FIIContext>();

            // Add framework services.
            services.AddMvc(config =>
            {
                if (_env.IsProduction())
                    config.Filters.Add(new RequireHttpsAttribute());
            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            AnnouncementSeedData seed)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });


            seed.EnsureSeedData().Wait();
            seed.AddRoles().Wait();
        }
    }
}