using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vejrstation.Data;
using Vejrstation.Hubs;
using Vejrstation.Interfaces;
using Vejrstation.Repository;




namespace Vejrstation
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
            var connString = System.Environment.GetEnvironmentVariable("WeatherServerDb");
            services.AddControllers().AddControllersAsServices();
            
            services.AddDbContext<WeatherServerDbContext>(options =>
                options.UseSqlServer(connString));
            
            services.AddSignalR();
            

            
            services.AddScoped<IWeatherObservationRepository, WeatherObservationRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WeatherServerDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LiveUpdateHub>("/LiveUpdateHub");
            });
        }
        
    }
}