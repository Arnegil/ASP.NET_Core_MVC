using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }*/

            app.Use(async (context, next) =>
            {
                Watcher watcher = new Watcher();
                watcher.Start();
                await context.Response.WriteAsync("<br>Start first watcher!");
                await next();
                watcher.End();
                await context.Response.WriteAsync($"<br>First watcher: {watcher.Milliseconds} ms");
            });

            app.Use(async (context, next) =>
            {
                Watcher watcher = new Watcher();
                watcher.Start();
                await context.Response.WriteAsync("<br>Start second watcher!");
                await next();
                watcher.End();
                await context.Response.WriteAsync($"<br>Second watcher: {watcher.Milliseconds} ms");
            });

            app.UseMiddleware<MyMiddleware>();

            app.Use(async (context, next) =>
            {
                Watcher watcher = new Watcher();
                watcher.Start();
                await context.Response.WriteAsync("<br>Start fourth watcher!");
                watcher.End();
                await context.Response.WriteAsync($"<br>Fourth watcher: {watcher.Milliseconds} ms");
            });

            /*app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });*/
        }
    }
}
