
namespace Eventos.IO.Domain.Interfaces
{
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        int Adicionar(List<TEntity> obj);
        TEntity ObterPorId(Guid id);
        List<TEntity> ObterTodos();
        List<TEntity> ObterTodos(int take = 100, int skip = 0, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
