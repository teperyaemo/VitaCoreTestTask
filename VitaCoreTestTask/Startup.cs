using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Data.Repository;

namespace VitaCoreTestTask
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
            services.AddControllersWithViews(); 
            services.AddDbContext<VCappContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IPet, PetRepository>();
            services.AddTransient<IPetOwner, PetOwnerRepository>();
            services.AddTransient<IPetVac, PetVacRepository>();
            services.AddTransient<ISpecies, SpeciesRepository>();
            services.AddTransient<IBreed, BreedRepository>();
            services.AddTransient<IVaccination, VaccinationRepository>();
            services.AddTransient<IEmployee, EmplyeeRepository>();
            services.AddTransient<IVisitLog, VisitLogRepository>();
            services.AddTransient<IRenderedService, RenderedServiceRepository>();
            services.AddTransient<IService, ServiceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
