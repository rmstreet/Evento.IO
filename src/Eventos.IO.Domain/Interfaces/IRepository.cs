
namespace Eventos.IO.Domain.Interfaces
{
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
