using DDDCore.Domain.Interface;
using DDDCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDDCore.Infra.Data.Repositories
{
  public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
  {
    protected readonly SqlServerContext Db;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(SqlServerContext context)
    {
      Db = context;
      DbSet = Db.Set<TEntity>();
    }

    public virtual void Add(TEntity obj)
    {
      DbSet.Add(obj);
    }

    public virtual TEntity GetById(int id)
    {
      return DbSet.Find(id);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
      return DbSet;
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
    {
      return DbSet.Where(filter).ToList();
    }

    public virtual void Update(int id, TEntity obj)
    {
      //DbSet.Find(id);
      if (Db.Entry(obj).State == EntityState.Detached) Db.Set<TEntity>().Attach(obj);
      Db.Entry(obj).State = EntityState.Modified;
    }

    public virtual void Remove(int id)
    {
      DbSet.Remove(DbSet.Find(id));
    }

    public virtual void Remove(TEntity obj)
    {
      DbSet.Remove(obj);
    }

    public virtual int SaveChanges()
    {
      return Db.SaveChanges();
    }

    public void Dispose()
    {
      Db.Dispose();
      GC.SuppressFinalize(this);
    }
  }
}
