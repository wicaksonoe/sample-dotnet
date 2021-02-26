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
        private readonly UserRepository userRepository;

        public ProfileService(ProfileRepository profileRepository, UserRepository userRepository)
        {
            this.profileRepository = profileRepository;
            this.userRepository = userRepository;
        }

        public async Task<Profile> GetProfile(long userId)
        {
            var profile = await profileRepository.GetByCondition(p => p.UserId == userId);

            if (profile.Any() == false)
            {
                return new Profile();
            }

            return profile.First();
        }

        public async Task<Profile> UpdateProfile(long userId, Profile profile)
        {
            var user = await userRepository.FindById(userId);

            user.Profile = profile;
            await userRepository.Update(user);

            return profile;
        }
    }
}
