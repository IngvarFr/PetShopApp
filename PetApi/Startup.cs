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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PetShopDbContext>(opt => opt.UseInMemoryDatabase("TheDB"));
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.BuildServiceProvider();

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
                    var own1 = new Owner() { FirstName = "Bob", LastName = "Barker", Address = "Happy Street 23", Email = "bob@barker.com", PhoneNumber = "9549-8724" };
                    var own2 = new Owner() { FirstName = "Jessie", LastName = "Smith", Address = "Shark Beach 42", Email = "jess@gmail.com", PhoneNumber = "3584-1287" };
                    var own3 = new Owner() { FirstName = "Carl", LastName = "Comb", Address = "Neville Lane 12", Email = "carl@yahoo.com", PhoneNumber = "8925-4153" };
                    var own4 = new Owner() { FirstName = "Tim", LastName = "Turner", Address = "Magpie Way 8", Email = "tim@hotmail.com", PhoneNumber = "9813-5485" };

                    ctx.Pets.Add(new Pet() { Name = "Sam", Type = "Dog", Price = 200, Birthdate = new DateTime(2004, 3, 12), PreviousOwner = own1 });
                    ctx.Pets.Add(new Pet() { Name = "Maggie", Type = "Cat", Price = 150, Birthdate = new DateTime(2007, 12, 14), PreviousOwner = own2 });
                    ctx.Pets.Add(new Pet() { Name = "Ella", Type = "Rabbit", Price = 120, Birthdate = new DateTime(2009, 7, 25), PreviousOwner = own3 });
                    ctx.Pets.Add(new Pet() { Name = "Hammy", Type = "Hamster", Price = 75, Birthdate = new DateTime(2014, 1, 18), PreviousOwner = own3 });


                    
                    ctx.SaveChanges();
                }
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
