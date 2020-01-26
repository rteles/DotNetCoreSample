using System.Collections.Generic;
using DotNetSample.Domain.Entities;

namespace DotNetSample.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetUsers(bool onlyActives);
    }
}