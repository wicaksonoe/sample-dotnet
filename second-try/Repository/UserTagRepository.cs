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

        public UserTagRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UserTag>> BulkAdd(UserTag[] userTags)
        {
            await appDbContext.AddRangeAsync(userTags);
            await appDbContext.SaveChangesAsync();
            
            return userTags;
        }

        public async Task<IEnumerable<UserTag>> BulkUpdate(UserTag[] userTags)
        {
            appDbContext.UpdateRange(userTags);
            await appDbContext.SaveChangesAsync();

            return userTags;
        }
    }
}
