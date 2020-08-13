using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
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

        public void AddUser(User user)
        {
            this.userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.FindAll();
        }

        public User GetUserById(long id)
        {
            return userRepository.Find(id);
        }

        public void RemoveUser(long id)
        {
            userRepository.Delete(id);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }
    }
}
