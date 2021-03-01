using Microsoft.EntityFrameworkCore;
using second_try.Interfaces;
using second_try.Models;
using second_try.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly IQueryable<User> user;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.user = appDbContext.Users
                .Include(u => u.Profile)
                .Include(u => u.Vehicles)
                .Include(u => u.UserTags)
                    .ThenInclude(ut => ut.Tag)
                .AsQueryable();
        }

        public async Task<IEnumerable<User>> GetAll(UserRequest payload)
        {
            var users = this.user;

            if (payload.Username != null)
            {
                users = users.Where(u => u.Username == payload.Username);
            }

            if (payload.Email != null)
            {
                users = users.Where(u => u.Email == payload.Email);
            }

            return await users.ToListAsync();
        }

        public override async Task<IEnumerable<User>> GetByCondition(Expression<Func<User, bool>> expression) => await this.user.Where(expression).ToListAsync();
    }
}
