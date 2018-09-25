using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();

        Owner CreateOwner(Owner owner);

        Owner GetOwnerById(int id);

        Owner UpdateOwner(Owner owner);

        Owner RemoveOwner(Owner owner);

    }
}
