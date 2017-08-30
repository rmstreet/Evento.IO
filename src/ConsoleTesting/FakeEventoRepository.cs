using System;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Eventos;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleTesting
{
    public class FakeEventoRepository : IEventoRepository
    {
        public void Adicionar(Evento obj)
        {
            //
        }

        public void Dispose()
        {
            //
        }

        public List<Evento> Buscar(Expression<Func<Evento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Evento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Evento ObterPorId(Guid id)
        {
            return new Evento("Fake", DateTime.Now, DateTime.Now, true, 0, true, "Empresa A");
        }

        public void Remover(Guid id)
        {
            //
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Evento obj)
        {
            //
        }
    }

}