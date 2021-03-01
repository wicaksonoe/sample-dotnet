using Microsoft.EntityFrameworkCore;
using second_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Repository
{
    public class UserTagRepository : RepositoryBase<UserTag>
    {
        private readonly AppDbContext appDbContext;
        private readonly IQueryable<UserTag> userTags;

        public UserTagRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
            this.userTags = appDbContext.UserTags
                .Include(ut => ut.User)
                .Include(ut => ut.Tag)
                .AsQueryable();
        }

        public async Task<IEnumerable<UserTag>> BulkAdd(UserTag[] userTags)
        {
            await appDbContext.UserTags.AddRangeAsync(userTags);
            await appDbContext.SaveChangesAsync();
            
            return userTags;
        }

        public async Task<IEnumerable<UserTag>> BulkUpdate(UserTag[] userTags)
        {
            appDbContext.UserTags.UpdateRange(userTags);
            await appDbContext.SaveChangesAsync();

            return userTags;
        }

        public async Task<IEnumerable<UserTag>> BulkDelete(UserTag[] userTags)
        {
            appDbContext.UserTags.RemoveRange(userTags);
            await appDbContext.SaveChangesAsync();

            return userTags;
        }

        public override async Task<UserTag> FindById(long id)
        {
            return await this.userTags.Where(ut => ut.Id == id).FirstAsync();
        }
    }
}
