﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprotify.Domain.Models;
using Sprotify.Domain.Repositories;

namespace Sprotify.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SprotifyDbContext _context;

        public UserRepository(SprotifyDbContext context)
        {
            _context = context;
        }

        public Task<User> GetById(Guid id)
        {
            return _context.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public User Create(User user)
        {
            return _context.Set<User>().Add(user).Entity;
        }
    }
}