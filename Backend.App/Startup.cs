using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.Service;
using Common.Logging;

namespace Backend.App
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

            services.AddControllers();

            services.AddSingleton<IGetRegistrados, ServicesGetRegistrados>();
            services.AddSingleton<IPostRegistrados, ServicesPostRegistrados>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
             , ILoggerFactory loggerFactory
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                loggerFactory.AddSyslog(
                    Configuration.GetValue<string>("Papertrail:host"),
                    Configuration.GetValue<int>("Papertrail:port"));

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
