
namespace Eventos.IO.Infra.Data.Repository
{
    using Eventos.IO.Domain.Core.Models;
    using Eventos.IO.Domain.Interfaces;
    using Eventos.IO.Infra.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected EventosContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(EventosContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }
        
        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public List<TEntity> ObterTodos(int take = 1000, int skip = 0, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            List<TEntity> lista = null;

            var query = from item in DbSet.AsNoTracking()
                        orderby orderBy
                        select item;

            if (filter != null && (take != 0 || skip != 0))
                lista = query
                        .Where(filter)
                        .Take(take)
                        .Skip(skip)
                        .ToList();

            if (filter != null && take == 0 && skip == 0)
                lista = query
                    .Where(filter)
                    .Take(1000)
                    .ToList();

            else if (filter == null && take == 0 && skip == 0)
                lista = query
                    .Take(1000)
                    .ToList();

            else
                lista = query
                     .Take(take)
                     .Skip(skip)
                     .ToList();

            return lista;
        }

        public virtual void Remover(Guid id)
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
        }

        
    }
}
