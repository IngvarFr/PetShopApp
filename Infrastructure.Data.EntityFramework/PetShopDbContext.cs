using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EntityFramework
{
    public class PetShopDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public PetShopDbContext(DbContextOptions<PetShopDbContext> opt): base(opt)
        {
            
        }

        
    }
}
