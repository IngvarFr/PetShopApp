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
            _ctx.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.AsNoTracking().FirstOrDefault(o => o.Id.Equals(id));
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner RemoveOwner(Owner owner)
        {
            _ctx.Attach(owner).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            _ctx.Entry(owner).State = EntityState.Detached;
            _ctx.Attach(owner).State = EntityState.Modified;
            _ctx.SaveChanges();
            return owner;
        }
    }
}
