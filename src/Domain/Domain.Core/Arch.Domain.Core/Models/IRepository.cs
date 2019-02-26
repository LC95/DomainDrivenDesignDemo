using System;
using System.Linq;

namespace Arch.Domain.Core.Models {
    public interface IRepository<TKey, TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(TKey id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TKey id);
        int SaveChanges();
    }
}