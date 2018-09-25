using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();

        List<Pet> GetPetsIncludeOwner();

        Pet NewPet(Pet pet);

        List<Pet> GetPetsByPrice();

        List<Pet> SearchByType(string type);

        Pet DeletePet(int id);

        Pet GetPetById(int id);

        Pet GetPetByIdIncludeOwner(int id);

        Pet UpdatePet(Pet updatePet);

        List<Pet> GetFiveCheapest();

        List<Pet> GetFilteredPets(Filter filter);
    }
}
