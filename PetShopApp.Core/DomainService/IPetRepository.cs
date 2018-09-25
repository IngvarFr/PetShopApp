using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        IEnumerable<Pet> ReadPetsIncludeOwners();

        Pet CreatePet(Pet pet);

        Pet GetPetById(int id);

        Pet GetPetByIdIncludeOwner(int id);

        Pet UpdatePet(Pet pet);

        Pet RemovePet(Pet pet);

        IEnumerable<Pet> GetFilteredPets(Filter filter);
    }
}
