using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using second_try.Models;
using second_try.Requests;
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

        public UsersController(UserService userService)
        {
            this.UserService = userService;
        }


        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers(UserRequest payload)
        {
            var data = await UserService.GetUsers(payload);

            return Ok(new
            {
                message = "query success",
                data = data
            });
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(long id)
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
        public async Task<ActionResult> PostNewUser(User newUser)
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
        public async Task<ActionResult> UpdateUser(long id, User user)
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
        public async Task<ActionResult> DeleteUsers(long id)
        {
            await UserService.DeleteUser(id);

            return Ok(new
            {
                message = "Data deleted"
            });
        }
    }
}
