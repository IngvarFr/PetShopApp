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

        private static List<Pet> petList;

        private static int id = 1;

        public static void InitData()
        {
            petList = new List<Pet>();
            petList.Add(new Pet() { Name = "Sam", Type = "Dog", Price = 200, Id = id++, Birthdate = new DateTime(2004, 3, 12) });
            petList.Add(new Pet() { Name = "Maggie", Type = "Cat", Price = 150, Id = id++, Birthdate = new DateTime(2007, 12, 14) });
            petList.Add(new Pet() { Name = "Ella", Type = "Rabbit", Price = 120, Id = id++, Birthdate = new DateTime(2009, 7, 25) });
            petList.Add(new Pet() { Name = "Hammy", Type = "Hamster", Price = 75, Id = id++, Birthdate = new DateTime(2014, 1, 18) });
            petList.Add(new Pet() { Name = "Doggo", Type = "Dog", Price = 175, Id = id++, Birthdate = new DateTime(2016, 8, 30) });
            petList.Add(new Pet() { Name = "Steve", Type = "Mouse", Price = 100, Id = id++, Birthdate = new DateTime(2018, 4, 24) });
            petList.Add(new Pet() { Name = "Squawks", Type = "Parrot", Price = 300, Id = id++, Birthdate = new DateTime(2015, 2, 28) });
            petList.Add(new Pet() { Name = "Jo", Type = "Cat", Price = 160, Id = id++, Birthdate = new DateTime(2017, 10, 9) });
            petList.Add(new Pet() { Name = "Cleo", Type = "Rabbit", Price = 135, Id = id++, Birthdate = new DateTime(2011, 5, 5) });
            petList.Add(new Pet() { Name = "Manny", Type = "Lizard", Price = 220, Id = id++, Birthdate = new DateTime(2002, 6, 17) });
            petList.Add(new Pet() { Name = "Noodle", Type = "Snake", Price = 500, Id = id++, Birthdate = new DateTime(2008, 11, 14) });
            Pets = petList;
        }

        public static Pet AddPet(Pet pet)
        {
            pet.Id = id++;
            petList.Add(pet);
            Pets = petList;
            return pet;
        }

        public static Pet RemovePet(Pet pet)
        {
            petList.Remove(pet);
            Pets = petList;
            return pet;
        }
    }
}
