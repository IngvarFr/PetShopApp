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
            var pet1 = _ctx.Add(pet).Entity;
            _ctx.SaveChanges();
            return pet1;
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet RemovePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
