using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; } // DB ÝÇÝN EKLENDÝ

        public Startup(IConfiguration configuration) // DB ÝÇÝN EKLENDÝ
        {
            Configuration = configuration; // DB ÝÇÝN EKLENDÝ
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<movieContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))); // DB ÝÇÝN EKLENDÝ

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }

            app.UseStaticFiles(); //wwwroot kýsmýný kullanýma açýyor.

            app.UseRouting();

            // localhost:5000
            // localhost:5000/movies

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                        name:"default",
                        pattern:"{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
