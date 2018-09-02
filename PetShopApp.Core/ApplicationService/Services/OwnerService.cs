using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerToDelete = GetOwnerById(id);
            return _ownerRepository.RemoveOwner(ownerToDelete);
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }

        public Owner NewOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public void UpdateOwner(Owner updateOwner)
        {
            var ownerToUpdate = GetOwnerById(updateOwner.Id);
            ownerToUpdate.FirstName = updateOwner.FirstName;
            ownerToUpdate.LastName = updateOwner.LastName;
            ownerToUpdate.Address = updateOwner.Address;
            ownerToUpdate.Email = updateOwner.Email;
            ownerToUpdate.PhoneNumber = updateOwner.PhoneNumber;
        }
    }
}
