using System;
using System.Linq;
using Arch.Data.EntityFramework.Context;
using Arch.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Arch.Data.EntityFramework.Repositories {
    public class Repository<Tkey,TEntity> : IRepository<Tkey, TEntity> where TEntity : Entity
    {
        protected readonly ArchContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ArchContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
           DbSet.Add(obj);
        }

        public TEntity GetById(Tkey id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Update(TEntity obj)
        {
           DbSet.Update(obj);
        }

        public void Remove(Tkey id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
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
