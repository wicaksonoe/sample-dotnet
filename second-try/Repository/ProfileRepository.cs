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
    public class ProfileRepository : RepositoryBase<Profile>
    {
        private readonly IQueryable<Profile> profile;

        public ProfileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.profile = appDbContext.Profiles.AsQueryable();
        }

        public async Task<Profile> AddOrUpdateProfile(Profile profile)
        {
            var result = this.profile.AsNoTracking().FirstOrDefault(p => p.Id == profile.Id || p.UserId == profile.UserId);

            if (result == null)
            {
                return await Add(profile);
            }
            else
            {
                return await Update(profile);
            }
            
        }
    }
}
