using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Isen.Dotnet.Web
{
    public class Startup
    {
        // Constructeur
        public Startup(
            // d'où vient ce param ??
            IConfiguration configuration)
        {
            Console.WriteLine("Startup.Ctor");
            // le param est stocké dans une variable membre
            Configuration = configuration;
        }
        // la variable membre
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices(
            IServiceCollection services)
        {
            Console.WriteLine("Startup.ConfigureServices");
            // Pipeline des services injectés: +SQLite
            services.AddDbContext<ApplicationDbContext>(
                // Fonction anonyme (lambda) pour la config
                builder => 
                // Indiquer qu'on se base sur SQLite
                builder.UseSqlite(
                    // Passer la chaine de connexion SQLite
                    Configuration.GetConnectionString("DefaultConnection")));
            // Pipeline des services injectés: + MVC
            services
            // Injection de ASP.NET MVC
                .AddControllersWithViews()
            // Injection de la compilation à la volée des vues Razor
                .AddRazorRuntimeCompilation();

            // Injection de mes services
            services.AddScoped<IDataInitializer, DataInitializer>();
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            Console.WriteLine("Startup.Configure");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
