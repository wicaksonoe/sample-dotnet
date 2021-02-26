using Microsoft.EntityFrameworkCore;
using second_try.Models;
using second_try.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FindUserById(long id)
        {
            var users = await _userRepository.GetByCondition(u => u.Id == id);

            return users.First();
        }

        public async Task<IEnumerable<User>> GetUsers(string? username, string? email)
        {
            return await _userRepository.GetAll(username, email);
        }

        public async Task<User> InsertUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<User> UpdateUser(long id, User user)
        {
            if (id != user.Id)
            {
                throw new Exception("Bad request");
            }

            return await _userRepository.Update(user);
        }

        public async Task<User> DeleteUser(long id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
