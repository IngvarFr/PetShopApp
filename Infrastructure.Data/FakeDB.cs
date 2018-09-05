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

        public static IEnumerable<Owner> Owners { get; set; }

        private static List<Pet> petList;

        private static List<Owner> ownerList;

        private static int id = 1;
        private static int ownerId = 1;

        public static void InitData()
        {
            petList = new List<Pet>();
            petList.Add(new Pet() { Name = "Sam", Type = "Dog", Price = 200, Id = id++, Birthdate = new DateTime(2004, 3, 12), PreviousOwner = new Owner() { Id = 1 } });
            petList.Add(new Pet() { Name = "Maggie", Type = "Cat", Price = 150, Id = id++, Birthdate = new DateTime(2007, 12, 14), PreviousOwner = new Owner() { Id = 2 } });
            petList.Add(new Pet() { Name = "Ella", Type = "Rabbit", Price = 120, Id = id++, Birthdate = new DateTime(2009, 7, 25), PreviousOwner = new Owner() { Id = 6 } });
            petList.Add(new Pet() { Name = "Hammy", Type = "Hamster", Price = 75, Id = id++, Birthdate = new DateTime(2014, 1, 18), PreviousOwner = new Owner() { Id = 3 } });
            petList.Add(new Pet() { Name = "Doggo", Type = "Dog", Price = 175, Id = id++, Birthdate = new DateTime(2016, 8, 30), PreviousOwner = new Owner() { Id = 5 } });
            petList.Add(new Pet() { Name = "Steve", Type = "Mouse", Price = 100, Id = id++, Birthdate = new DateTime(2018, 4, 24), PreviousOwner = new Owner() { Id = 2 } });
            petList.Add(new Pet() { Name = "Squawks", Type = "Parrot", Price = 300, Id = id++, Birthdate = new DateTime(2015, 2, 28), PreviousOwner = new Owner() { Id = 3 } });
            petList.Add(new Pet() { Name = "Jo", Type = "Cat", Price = 160, Id = id++, Birthdate = new DateTime(2017, 10, 9), PreviousOwner = new Owner() { Id = 4 } });
            petList.Add(new Pet() { Name = "Cleo", Type = "Rabbit", Price = 135, Id = id++, Birthdate = new DateTime(2011, 5, 5), PreviousOwner = new Owner() { Id = 6 } });
            petList.Add(new Pet() { Name = "Manny", Type = "Lizard", Price = 220, Id = id++, Birthdate = new DateTime(2002, 6, 17), PreviousOwner = new Owner() { Id = 2 } });
            petList.Add(new Pet() { Name = "Noodle", Type = "Snake", Price = 500, Id = id++, Birthdate = new DateTime(2008, 11, 14), PreviousOwner = new Owner() { Id = 1 } });
            Pets = petList;

            ownerList = new List<Owner>();
            ownerList.Add(new Owner() { FirstName = "Bob", LastName = "Barker", Address = "Happy Street 23", Email = "bob@barker.com", PhoneNumber = "95498724", Id = ownerId++ });
            ownerList.Add(new Owner() { FirstName = "Jessie", LastName = "Smith", Address = "Shark Beach 42", Email = "jess@gmail.com", PhoneNumber = "35841287", Id = ownerId++ });
            ownerList.Add(new Owner() { FirstName = "Carl", LastName = "Comb", Address = "Neville Lane 12", Email = "carl@yahoo.com", PhoneNumber = "89254153", Id = ownerId++ });
            ownerList.Add(new Owner() { FirstName = "Tim", LastName = "Turner", Address = "Magpie Way 8", Email = "tim@hotmail.com", PhoneNumber = "98135485", Id = ownerId++ });
            ownerList.Add(new Owner() { FirstName = "Jimmy", LastName = "Johnson", Address = "Memory Lane 45", Email = "jim@jim.com", PhoneNumber = "24881681", Id = ownerId++ });
            ownerList.Add(new Owner() { FirstName = "Marie", LastName = "Carlson", Address = "Beverly Hills  34", Email = "marie@company.com", PhoneNumber = "57984354", Id = ownerId++ });
            Owners = ownerList;
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

        public static Owner AddOwner(Owner owner)
        {
            owner.Id = ownerId++;
            ownerList.Add(owner);
            Owners = ownerList;
            return owner;
        }

        public static Owner RemoveOwner(Owner owner)
        {
            ownerList.Remove(owner);
            Owners = ownerList;
            return owner;
        }
    }
}
