using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using second_try.Models;
using second_try.Requests;
using second_try.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: api/profile/5
        [HttpGet]
        public async Task<IActionResult> GetProfile([FromBody] ProfileRequest payload)
        {
            var profile = await profileService.GetProfile(payload.UserId);

            return Ok(new
            {
                message = "profile obtained",
                data = profile
            });
        }

        // PUT: api/profile
        [HttpPut]
        public async Task<IActionResult> UpdateProfile(Profile profile)
        {
            var result = await profileService.UpdateProfile(profile);

            return Ok(new
            {
                message = "Profile updated",
                data = result
            });
        }
    }
}
