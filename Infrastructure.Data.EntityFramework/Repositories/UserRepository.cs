using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopDbContext _ctx;

        public UserRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteUser(long id)
        {
            var user = GetUsers().FirstOrDefault(u => u.Id == id);
            _ctx.Attach(user).State = EntityState.Deleted;
            _ctx.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users;
        }

        public User NewUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return user;
        }
    }
}
