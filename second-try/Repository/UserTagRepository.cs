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
            foreach (UserTag userTag in userTags)
            {
                appDbContext.UserTags.Add(userTag);
            }

            await appDbContext.SaveChangesAsync();
            
            return userTags;
        }

        public async Task<IEnumerable<UserTag>> BulkUpdate(UserTag[] userTags)
        {
            foreach (UserTag userTag in userTags)
            {
                appDbContext.UserTags.Update(userTag);
            }

            await appDbContext.SaveChangesAsync();

            return userTags;
        }
    }
}
