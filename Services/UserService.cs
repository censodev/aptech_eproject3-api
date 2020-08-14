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

        public bool Add(User user)
        {
            return userRepository.Add(user);
        }

        public IEnumerable<User> FindAll()
        {
            return userRepository.FindAll();
        }

        public User FindByUsername(string username)
        {
            return userRepository.FindByUsername(username);
        }

        public User FindById(long id)
        {
            return userRepository.Find(id);
        }

        public bool Remove(long id)
        {
            return userRepository.Delete(id);
        }

        public bool Update(User user)
        {
            return userRepository.Update(user);
        }

        public User FindByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }
    }
}
