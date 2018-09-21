using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data.EntityFramework;

namespace PetApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<PetShopDbContext>();
                ctx.Database.EnsureCreated();
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
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
