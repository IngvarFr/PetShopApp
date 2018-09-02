using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();

        Owner NewOwner(Owner owner);

        Owner DeleteOwner(int id);

        Owner GetOwnerById(int id);

        void UpdateOwner(Owner updateOwner);
    }
}
