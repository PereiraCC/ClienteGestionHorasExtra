using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra
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

                endpoints.MapControllerRoute(
                    name: "registro",
                    pattern: "{controller=Home}/{action=Registro}/{id?}");

                endpoints.MapControllerRoute(
                    name: "tareas",
                    pattern: "{controller=Funcionarios}/{action=Tareas}/{id?}");

                endpoints.MapControllerRoute(
                    name: "formulariosAvalados",
                    pattern: "{controller=Funcionarios}/{action=FormulariosAvalados}/{id?}");

                endpoints.MapControllerRoute(
                    name: "formulariosReportes",
                    pattern: "{controller=Funcionarios}/{action=FormulariosReportes}/{id?}");

                endpoints.MapControllerRoute(
                    name: "evidencias",
                    pattern: "{controller=Funcionarios}/{action=Evidencias}/{id?}");

                endpoints.MapControllerRoute(
                    name: "enviarSolicitud",
                    pattern: "{controller=Jefatura}/{action=EnviarSolicitud}/{id?}");

                endpoints.MapControllerRoute(
                    name: "evidenciasJefatura",
                    pattern: "{controller=Jefatura}/{action=Evidencias}/{id?}");

                endpoints.MapControllerRoute(
                    name: "aprobacionHoras",
                    pattern: "{controller=DirectorAdmin}/{action=AprobacionHoras}/{id?}");

                endpoints.MapControllerRoute(
                    name: "pendientes",
                    pattern: "{controller=ControlTiempo}/{action=Pendientes}/{id?}");

                endpoints.MapControllerRoute(
                    name: "jornadas",
                    pattern: "{controller=ControlTiempo}/{action=Jornadas}/{id?}");

                endpoints.MapControllerRoute(
                    name: "pagos",
                    pattern: "{controller=Planilla}/{action=Pagos}/{id?}");
            });
        }
    }  
}
