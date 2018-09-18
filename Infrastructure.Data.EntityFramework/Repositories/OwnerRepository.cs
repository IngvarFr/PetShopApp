using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var own = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return own;
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id.Equals(id));
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner RemoveOwner(Owner owner)
        {
            var o = _ctx.Owners.Remove(owner).Entity;
            _ctx.SaveChanges();
            return o;
        }
    }
}
