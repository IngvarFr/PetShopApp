using PetShopApp.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PetShopApp.Core.Entities;

namespace PetShopApp.UI
{
    class Printer : IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void PrintPets()
        {
            var pets = _petService.GetPets();
            foreach(Pet pet in pets)
            {
                Console.WriteLine($"Name: {pet.Name}  Type: {pet.Type}  Price: {pet.Price}");
            }
            Console.ReadLine();

        }
    }
}
