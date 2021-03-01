using second_try.Models;
using second_try.Repository;
using second_try.Requests;
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

        public async Task<IEnumerable<UserTag>> AddTags(UserTag[] userTags)
        {
            return await userTagRepository.BulkAdd(userTags);
        }

        public async Task<IEnumerable<UserTag>> UpdateTags(UserTag[] userTags)
        {
            return await userTagRepository.BulkUpdate(userTags);
        }
        public async Task<IEnumerable<UserTag>> DeleteTags(UserTag[] userTags)
        {
            return await userTagRepository.BulkDelete(userTags);
        }

        public async Task<IEnumerable<UserTag>> GetUserTags(UserTagRequest userTagRequest)
        {
            return await userTagRepository.GetByCondition(u => u.UserId == userTagRequest.UserId);
        }

        public async Task<UserTag> FindUserTag(long id)
        {
            return await userTagRepository.FindById(id);
        }
    }
}
