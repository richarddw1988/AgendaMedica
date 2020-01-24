using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDDCore.Domain.Interface
{
  public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
  {
    void Add(TEntity obj);

    TEntity GetById(int id);

    IQueryable<TEntity> GetAll();

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

    void Update(int id, TEntity obj);

    void Remove(int id);
   
    void Remove(TEntity obj);

    int SaveChanges();
  }
}
