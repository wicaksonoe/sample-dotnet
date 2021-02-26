using Microsoft.AspNetCore.Mvc;
using second_try.Models;
using second_try.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace second_try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagService tagService;

        public TagsController(TagService tagService)
        {
            this.tagService = tagService;
        }

        // GET: api/tags
        [HttpGet]
        public async Task<IEnumerable<Tag>> Get()
        {
            return await tagService.GetAllTags();
        }

        // GET api/tags/5
        [HttpGet("{id}")]
        public async Task<Tag> Get(long id)
        {
            return await tagService.GetTag(id);
        }

        // POST api/tags
        [HttpPost]
        public async Task<Tag> Post(Tag tag)
        {
            return await tagService.InsertTag(tag);
        }

        // PUT api/tags/5
        [HttpPut("{id}")]
        public async Task<Tag> Put(long id, Tag tag)
        {
            return await tagService.UpdateTag(id, tag);
        }

        // DELETE api/tags/5
        [HttpDelete("{id}")]
        public async Task<Tag> Delete(long id)
        {
            return await tagService.DeleteTag(id);
        }
    }
}
