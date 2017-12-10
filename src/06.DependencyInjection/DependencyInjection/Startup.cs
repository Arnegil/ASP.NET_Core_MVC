using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
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
            services.AddTransient<IStudentService, StudentService>(StudentServiceFactory);
            services.AddTransient<IStudentGenerator, StudentGenerator>(StudentGeneratorFactory); 
            services.AddTransient<IStudentHelper, StudentHelper>(); 
            services.AddSingleton<DataSource>();
            services.AddMvc();
        }

        private StudentService StudentServiceFactory(IServiceProvider serviceProvider)
        {
            return new StudentService(serviceProvider.GetService<DataSource>());
        }

        private StudentGenerator StudentGeneratorFactory(IServiceProvider serviceProvider)
        {
            return new StudentGenerator(serviceProvider.GetService<IStudentService>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Students}/{action=Index}");
            });
        }
    }
}
