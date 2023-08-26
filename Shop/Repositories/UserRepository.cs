using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AppUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(AppUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public Task<IEnumerable<AppUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserById(string id)
        {
            return _context.Users.FindAsync(id).Result;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false; 
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
