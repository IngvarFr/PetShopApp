using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.EntityFramework.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopDbContext _ctx;

        public PetRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            if (pet.PreviousOwner != null)
            {
                _ctx.Attach(pet.PreviousOwner);
            }
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> GetFilteredPets(Filter filter)
        {
            return _ctx.Pets.Skip(filter.ItemsPerPage * (filter.CurrentPage - 1)).Take(filter.ItemsPerPage);
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Pet GetPetByIdIncludeOwner(int id)
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public IEnumerable<Pet> ReadPetsIncludeOwners()
        {
            return _ctx.Pets.Include(p => p.PreviousOwner);
        }

        public Pet RemovePet(Pet pet)
        {
            var p = _ctx.Pets.Remove(pet).Entity;
            _ctx.SaveChanges();
            return p;
        }

        public Pet UpdatePet(Pet pet)
        {
            if (pet.PreviousOwner != null && (_ctx.ChangeTracker.Entries<Pet>().FirstOrDefault(pe => pe.Entity.Id == pet.PreviousOwner.Id)) == null)
            {
                _ctx.Attach(pet.PreviousOwner);
            }

            _ctx.Entry(pet).Reference(p => p.PreviousOwner).IsModified = true;
            //var updated = _ctx.Update(pet).Entity;

            _ctx.Attach(pet).State = EntityState.Modified;

            _ctx.SaveChanges();
            return pet;
        }
    }
}
