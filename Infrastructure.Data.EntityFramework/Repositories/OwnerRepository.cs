using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EntityFramework.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopDbContext _ctx;

        public OwnerRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public Owner CreateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> ReadOwners()
        {
            throw new NotImplementedException();
        }

        public Owner RemoveOwner(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
