using Microsoft.AspNetCore.Mvc;
using second_try.Models;
using second_try.Requests;
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
    public class UserTagsController : ControllerBase
    {
        private readonly UserTagService userTagService;

        public UserTagsController(UserTagService userTagService)
        {
            this.userTagService = userTagService;
        }

        // GET: api/usertags
        [HttpGet]
        public async Task<IActionResult> Get(UserTagRequest userTagRequest)
        {
            if (userTagRequest.UserId == 0)
            {
                return BadRequest();
            }
            
            var data = await userTagService.GetUserTags(userTagRequest);
            return Ok(new
            {
                message = $"User {userTagRequest.UserId} tags received",
                data = data
            });
        }

        // GET api/usertags/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await userTagService.FindUserTag(id);
            return Ok(new
            {
                message = $"Usertag {id} detail obtained",
                data = data
            });
        }

        // POST api/usertags
        [HttpPost]
        public async Task<IActionResult> Post(UserTag[] userTags)
        {
            var data = await userTagService.AddTags(userTags);
            return Ok(new
            {
                message = "data inserted",
                data = data
            });
        }

        // PUT api/usertags
        [HttpPut]
        public async Task<IActionResult> Put(UserTag[] userTags)
        {
            var data = await userTagService.UpdateTags(userTags);
            return Ok(new
            {
                message = "data updated",
                data = data
            });
        }

        // DELETE api/usertags
        [HttpDelete]
        public async Task<IActionResult> Delete(UserTag[] userTags)
        {
            var data = await userTagService.DeleteTags(userTags);
            return Ok(new
            {
                message = "data deleted",
                data = data
            });
        }
    }
}
