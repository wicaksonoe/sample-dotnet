using Microsoft.EntityFrameworkCore;
using second_try.Interfaces;
using second_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly AppDbContext context;
        private readonly IQueryable<User> user;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.context = appDbContext;
            this.user = this.context.Users
                .Include(u => u.Profile)
                .AsQueryable();
        }

        public async Task<IEnumerable<User>> GetAll(string? username, string? email)
        {
            var users = this.user;

            if (username != null)
            {
                users = users.Where(u => u.Username == username);
            }

            if (email != null)
            {
                users = users.Where(u => u.Email == email);
            }

            return await users.ToListAsync();
        }

    }
}
