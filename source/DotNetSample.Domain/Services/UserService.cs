using System.Collections.Generic;
using DotNetSample.Domain.Interfaces.Repository;
using DotNetSample.Domain.Interfaces.Service;

namespace DotNetSample.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(Entities.User newUser)
        {
            _userRepository.Add(newUser);
        }

        public void UpdateUser(Entities.User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(Entities.User user)
        {
            _userRepository.Remove(user);
        }

        public IEnumerable<Entities.User> GetUsers(bool onlyActives)
        {
            return _userRepository.GetUsers(onlyActives);
        }

        public Entities.User GetUser(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}