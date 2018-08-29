using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> Pets { get; set; }

        public static void InitData()
        {
            var petList = new List<Pet>();
            petList.Add(new Pet() { Name = "Sam", Type = "Dog", Price = 200 });
            petList.Add(new Pet() { Name = "Maggie", Type = "Cat", Price = 150 });
            petList.Add(new Pet() { Name = "Ella", Type = "Rabbit", Price = 120 });
            petList.Add(new Pet() { Name = "Hammy", Type = "Hamster", Price = 75 });
            Pets = petList;
        }
    }
}
