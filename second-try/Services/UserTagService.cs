using second_try.Models;
using second_try.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Services
{
    public class UserTagService
    {
        private readonly UserTagRepository userTagRepository;

        public UserTagService(UserTagRepository userTagRepository)
        {
            this.userTagRepository = userTagRepository;
        }

        public async Task<IEnumerable<UserTag>> AddTags(UserTag[] tags)
        {
            return await userTagRepository.BulkAdd(tags);
        }

        public async Task<IEnumerable<UserTag>> UpdateTags(UserTag[] tags)
        {
            return await userTagRepository.BulkUpdate(tags);
        }

        public async Task<IEnumerable<UserTag>> DeleteTag()
        {
            throw new NotImplementedException();
        }
    }
}
