using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.Domain.Interface
{
    public interface IService<TEntity> : IDisposable where TEntity : class
  {

    TEntity GetById(int id);

    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

    void Add(TEntity obj);

    void Update(int id,TEntity obj);

    void Remove(TEntity obj);

    void SaveChanges();
  }
}
