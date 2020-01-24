using DDDCore.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DDDCore.Domain.Interface
{
  public interface IBaseService<TEntity> : IDisposable where TEntity : class
  {

    TEntity GetById(int id);

    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

    ValidationResult Add(TEntity obj);

    ValidationResult Update(int id,TEntity obj);

    ValidationResult Remove(TEntity obj);

    void SaveChanges();
  }
}
