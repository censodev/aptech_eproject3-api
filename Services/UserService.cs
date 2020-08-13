using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            return userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.FindAll();
        }

        public User GetByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }

        public User GetUserById(long id)
        {
            return userRepository.Find(id);
        }

        public bool RemoveUser(long id)
        {
            return userRepository.Delete(id);
        }

        public bool UpdateUser(User user)
        {
            return userRepository.Update(user);
        }
    }
}
