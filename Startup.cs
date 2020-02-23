using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc(); //aggiungo i servizi richiesti da MVC
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage(); //middleware eccezioni 
            }

            //if  (env.IsEnvironment("Production"))
            //{
            //    app.UseHttpsRedirection();
            //}
            app.UseStaticFiles(); //middleware per poter caricare file statici dal server

            //app.UseMvcWithDefaultRouting(); Questa è la router di default che fa praticamente quello che ho scritto nelle righe successive
            app.UseMvc(RouteBuilder =>
            {
                //courses/detail/5
                RouteBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); //Home , action hanno valori predifiniti Home  e Index per evitare l'errore 404 mentre id con il punto interrogativo diventa opzionale
            }); // si posso usare più di una route che verranno esaminate in ordine per vedere se c'è corrispondenza nel template

            
        }
    }
}
