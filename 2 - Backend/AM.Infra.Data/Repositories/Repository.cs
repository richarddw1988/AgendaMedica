using AM.Domain.Interface;
using AM.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AM.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Db;
        //protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext context)
        {
            Db = context;
            //DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            //DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
            //return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return Db.Set<TEntity>().Where(filter).ToList();  //DbSet.Where(filter).ToList();
        }

        public virtual void Update(int id, TEntity obj)
        {
            //DbSet.Find(id);
            if (Db.Entry(obj).State == EntityState.Detached) Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Remove(int id)
        {
            Db.Set<TEntity>().Remove(Db.Set<TEntity>().Find(id));
            ////DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Remove(TEntity obj)
        {
            //DbSet.Remove(obj);
            Db.Set<TEntity>().Remove(obj);
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
