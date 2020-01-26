using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNetSample.Domain.Entities;
using DotNetSample.Infra.Repository.Context;

namespace DotNetSample.Infra.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>, Domain.Interfaces.Repository.IUserRepository
    {
        public UserRepository(RepositoryContext db) : base(db)
        {
        }

        /// <summary>
        /// Entity framework test
        /// </summary>
        /// <param name="onlyActives"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(bool onlyActives)
        {
            var lstActiveUsers = _db.User.Where(_ => _.Active == onlyActives);
            return lstActiveUsers;
        }

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <returns></returns>
        public new IEnumerable<User> GetAll()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public new IEnumerable<User> GetAll(Expression<Func<User, bool>> filter)
        {
            return base.GetAll(filter);
        }

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new User GetById(int id)
        {
            return base.GetById(id);
        }
    }
}