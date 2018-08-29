using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        public PetRepository()
        {
            FakeDB.InitData();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }
    }
}
