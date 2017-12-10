using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part2.Interfaces;
using EF_part2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_part2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        private readonly string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=StudentsDB2;
            Integrated Security=True;
            Connect Timeout=60;
            Encrypt=False;
            TrustServerCertificate=True;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<StudentDbContext>(x => x.UseInMemoryDatabase("StudentsDB"));
            services.AddDbContext<StudentDbContext>(x => x.UseSqlServer(ConnectionString));

            services.AddTransient<IStudentService, StudentService>(StudentServiceFactory);
            services.AddTransient<IStudentGenerator, StudentGenerator>(StudentGeneratorFactory);
            services.AddTransient<IStudentHelper, StudentHelper>();

            services.AddMvc();
        }

        private StudentService StudentServiceFactory(IServiceProvider serviceProvider)
        {
            return new StudentService(serviceProvider.GetService<StudentDbContext>());
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
