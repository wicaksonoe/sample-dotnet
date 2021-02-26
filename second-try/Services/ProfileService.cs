using second_try.Models;
using second_try.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository profileRepository;

        public ProfileService(ProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<Profile> GetProfile(long userId)
        {
            // check if profile.UserId related to User.Id
            // .....


            var profile = await profileRepository.GetByCondition(p => p.UserId == userId);

            return profile.Any() ? profile.First() : null;
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            // check if profile.UserId related to User.Id
            // .....


            if (profile.Id == 0 && profile.UserId == 0)
            {
                throw new Exception("bad reqest");
            }

            var user = await profileRepository.AddOrUpdateProfile(profile);

            return user;
        }
    }
}
