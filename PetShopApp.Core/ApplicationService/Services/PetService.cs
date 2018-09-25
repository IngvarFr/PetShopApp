using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            var petToDelete = _petRepository.GetPetById(id);
            if(petToDelete != null)
            {
                return _petRepository.RemovePet(petToDelete);
            }
            else
            {
                return null;
            }
        }

        public Pet GetPetById(int id)
        {
            return _petRepository.GetPetById(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByPrice()
        {
            return _petRepository.ReadPets().OrderBy(p => p.Price).ToList();
        }

        public Pet NewPet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public List<Pet> SearchByType(string type)
        {
            return _petRepository.ReadPets().Where(p => p.Type.ToLower().Equals(type)).ToList();
        }

        public List<Pet> GetFiveCheapest()
        {
            var cheapestList = _petRepository.ReadPets().OrderBy(p => p.Price).Take(5).ToList();
            return cheapestList;
            
        }

        public List<Pet> GetPetsIncludeOwner()
        {
            return _petRepository.ReadPetsIncludeOwners().ToList();
        }

        public Pet GetPetByIdIncludeOwner(int id)
        {
            return _petRepository.GetPetByIdIncludeOwner(id);
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            return _petRepository.GetFilteredPets(filter).ToList();
        }
    }
}
