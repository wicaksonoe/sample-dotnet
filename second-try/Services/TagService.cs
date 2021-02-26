using second_try.Models;
using second_try.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Services
{
    public class TagService
    {
        private readonly TagRepository tagRepository;

        public TagService(TagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await tagRepository.GetAll();
        }

        public async Task<Tag> GetTag(long id)
        {
            return await tagRepository.FindById(id);
        }

        public async Task<Tag> InsertTag(Tag tag)
        {
            return await tagRepository.Add(tag);
        }

        public async Task<Tag> UpdateTag(long id, Tag tag)
        {
            if (id != tag.Id)
            {
                throw new Exception("Bad request");
            }

            return await tagRepository.Update(tag);
        }

        public async Task<Tag> DeleteTag(long id)
        {
            return await tagRepository.Delete(id);
        }
    }
}
