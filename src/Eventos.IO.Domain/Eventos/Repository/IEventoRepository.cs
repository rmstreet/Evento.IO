
namespace Eventos.IO.Domain.Eventos.Repository
{
    using Domain.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IEventoRepository : IRepository<Evento>
    {
        IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);
        Endereco ObterEnderecoPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
    }
}
