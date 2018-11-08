using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EntityFramework
{
    public static class DbSeeder
    {
        public static void Seed(PetShopDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var own1 = new Owner() { FirstName = "Bob", LastName = "Barker", Address = "Happy Street 23", Email = "bob@barker.com", PhoneNumber = "9549-8724" };
            var own2 = new Owner() { FirstName = "Jessie", LastName = "Smith", Address = "Shark Beach 42", Email = "jess@gmail.com", PhoneNumber = "3584-1287" };
            var own3 = new Owner() { FirstName = "Carl", LastName = "Comb", Address = "Neville Lane 12", Email = "carl@yahoo.com", PhoneNumber = "8925-4153" };
            var own4 = new Owner() { FirstName = "Tim", LastName = "Turner", Address = "Magpie Way 8", Email = "tim@hotmail.com", PhoneNumber = "9813-5485" };

            ctx.Attach(new Pet() { Name = "Sam", Type = "Dog", Price = 200, Birthdate = new DateTime(2004, 3, 12), PreviousOwner = own1 }).State = EntityState.Added;
            ctx.Attach(new Pet() { Name = "Maggie", Type = "Cat", Price = 150, Birthdate = new DateTime(2007, 12, 14), PreviousOwner = own2 }).State = EntityState.Added;
            ctx.Attach(new Pet() { Name = "Ella", Type = "Rabbit", Price = 120, Birthdate = new DateTime(2009, 7, 25), PreviousOwner = own3 }).State = EntityState.Added;
            ctx.Attach(new Pet() { Name = "Hammy", Type = "Hamster", Price = 75, Birthdate = new DateTime(2014, 1, 18), PreviousOwner = own3 }).State = EntityState.Added;

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAdmin, passwordSaltAdmin;

            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAdmin, out passwordSaltAdmin);

            var user = new User() { Username = "Joe", PasswordHash = passwordHashJoe, PasswordSalt = passwordSaltJoe, IsAdmin = false };
            var user2 = new User() { Username = "Admin", PasswordHash = passwordHashAdmin, PasswordSalt = passwordSaltAdmin, IsAdmin = true };

            ctx.Attach(user).State = EntityState.Added;
            ctx.Attach(user2).State = EntityState.Added;

            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
