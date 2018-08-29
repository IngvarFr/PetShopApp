using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Services;
using PetShopApp.Core.DomainService;
using System;

namespace PetShopApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicCollection = new ServiceCollection();
            servicCollection.AddScoped<IPrinter, Printer>();
            servicCollection.AddScoped<IPetService, PetService>();
            servicCollection.AddScoped<IPetRepository, PetRepository>();
            var serviceProvider = servicCollection.BuildServiceProvider();
            var printer = serviceProvider.GetService<IPrinter>();
            printer.PrintPets();
        }
    }
}
