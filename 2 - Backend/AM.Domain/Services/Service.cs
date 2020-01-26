using AM.Domain.Enum;
using AM.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return repository.Find(filter);
        }

        public virtual void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public virtual void Update(int id, TEntity obj)
        {
            repository.Update(id, obj);
        }

        public virtual void Remove(TEntity obj)
        {
            repository.Remove(obj);

        }

        public virtual void SaveChanges()
        {
            repository.SaveChanges();
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
