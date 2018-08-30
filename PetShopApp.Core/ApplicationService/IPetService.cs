using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();

        Pet NewPet(Pet pet);

        List<Pet> GetPetsByPrice();

        List<Pet> SearchByType(string type);

        Pet DeletePet(int id);

        Pet GetPetById(int id);

        void UpdatePet(Pet updatePet);

        List<Pet> GetFiveCheapest();
    }
}
