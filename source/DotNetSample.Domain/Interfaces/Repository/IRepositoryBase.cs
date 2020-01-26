using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotNetSample.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose(bool disposing);
    }
}