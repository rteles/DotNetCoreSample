using DotNetSample.Domain.Entities;

namespace DotNetSample.Domain.Interfaces.Service
{
    public interface IUserService : IServiceBase
    {
        void AddUser(User newUser);
        void UpdateUser(User user);
        System.Collections.Generic.IEnumerable<User> GetUsers(bool onlyActives);
        User GetUser(int userId);
        void DeleteUser(User user);
    }
}