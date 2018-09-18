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

        public void UpdatePet(Pet pet)
        {
            var petToUpdate = _petRepository.GetPetById(pet.Id);
            petToUpdate.Name = pet.Name;
            petToUpdate.Type = pet.Type;
            petToUpdate.Birthdate = pet.Birthdate;
            petToUpdate.Color = pet.Color;
            petToUpdate.Price = pet.Price;
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
            var pets = _petRepository.ReadPets();
            //foreach (var pet in _petRepository.ReadPets().ToList())
            //{
            //    pet.PreviousOwner = _ownerRepository.GetOwnerById(pet.PreviousOwner.Id);
            //}
            return pets.ToList();
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
    }
}
