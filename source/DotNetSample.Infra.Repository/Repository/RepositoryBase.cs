using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNetSample.Infra.Repository.Context;
using DotNetSample.Infra.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetSample.Infra.Repository.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly RepositoryContext _db;

        protected RepositoryBase(RepositoryContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _db.Set<TEntity>().Where(filter);
        }

        public void Update(TEntity obj)
        {
            DetachObj(obj);
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            //db.Set<TEntity>().Remove(obj);
            DetachObj(obj);
            _db.Entry(obj).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        private void DetachObj(TEntity obj)
        {
            var propKey = (from p in typeof(TEntity).GetProperties()
                where (p.Name.ToUpper().Equals("ID"))
                      && p.PropertyType == typeof(int)
                select p).First();

            if (propKey != null)
            {
                var e = _db.Set<TEntity>().Find(propKey.GetValue(obj));
                _db.Entry(e).State = EntityState.Detached;
            }
        }

        public void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}