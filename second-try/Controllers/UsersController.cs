using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using second_try.Models;
using second_try.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService UserService;
        private readonly ProfileService ProfileService;

        public UsersController(UserService userService, ProfileService profileService)
        {
            this.UserService = userService;
            this.ProfileService = profileService;
        }


        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers([FromQuery(Name = "username")] string username, [FromQuery(Name = "email")] string email)
        {
            var data = await UserService.GetUsers(username, email);

            return Ok(new
            {
                message = "query success",
                data = data
            });
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await UserService.FindUserById(id);

            return Ok(new
            {
                message = "query success",
                data = user
            });
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> PostNewUser(User newUser)
        {
            var data = await UserService.InsertUser(newUser);

            return Ok(new
            {
                message = "Data successfully added",
                data = data
            });
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, User user)
        {
            var data = await UserService.UpdateUser(id, user);

            return Ok(new
            {
                message = "Data updated",
                data = data
            });
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsers(long id)
        {
            await UserService.DeleteUser(id);

            return Ok(new
            {
                message = "Data deleted"
            });
        }

        // GET: api/users/profile/5
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(long id)
        {
            var profile = await ProfileService.GetProfile(id);

            return Ok(new
            {
                message = "profile obtained",
                data = profile.Id == 0 ? null : profile
            });
        }

        // PUT: api/users/profile/5
        [HttpPut("profile/{id}")]
        public async Task<IActionResult> UpdateProfile(long id, Profile profile)
        {
            var result = await ProfileService.UpdateProfile(id, profile);

            return Ok(new
            {
                message = "Profile updated",
                data = result
            });
        }

        // GET: api/users/5/vehicles

        // POST: api/users/5/vehicles

        // PUT: api/users/5/vehicles/1

        // DELETE: api/users/5/vehicles/1
    }
}
