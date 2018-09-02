using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner CreateOwner(Owner owner)
        {
            return FakeDB.AddOwner(owner);
        }

        public Owner GetOwnerById(int id)
        {
            return FakeDB.Owners.FirstOrDefault(o => o.Id.Equals(id));
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

        public Owner RemoveOwner(Owner owner)
        {
            return FakeDB.RemoveOwner(owner);
        }
    }
}
