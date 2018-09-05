using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        public Pet CreatePet(Pet pet)
        {
            return FakeDB.AddPet(pet);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet GetPetById(int id)
        {
            var pets = ReadPets();
            var listPets = pets.Where(p => p.Id.Equals(id)).ToList();
            if (listPets.Count != 0)
            {
                return listPets[0];
            }
            else
            {
                return null;
            }
        }

        public Pet RemovePet(Pet pet)
        {
            return FakeDB.RemovePet(pet);
        }
    }
}
