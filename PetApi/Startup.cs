using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Data.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Services;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;

namespace PetApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PetShopDbContext>(opt =>
                opt.UseSqlite("Data Source=PetShopApp.db"));

            }
            else
            {
                services.AddDbContext<PetShopDbContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
                //services.AddDbContext<PetShopDbContext>(opt => opt.UseInMemoryDatabase("DataBase"));
            }
            
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.BuildServiceProvider();
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopDbContext>();
                    DbSeeder.Seed(ctx);
                }

                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopDbContext>();
                    DbSeeder.Seed(ctx);
                }
                app.UseDeveloperExceptionPage();
                app.UseHsts();
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
