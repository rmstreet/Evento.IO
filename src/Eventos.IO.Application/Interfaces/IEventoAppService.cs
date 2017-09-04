
namespace Eventos.IO.Application.Interfaces
{
    using Eventos.IO.Application.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEventoAppService : IDisposable
    {
        void Registrar(EventoViewModel eventoViewModel);
        List<EventoViewModel> ObterTodos();
        List<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId);
        EventoViewModel ObterPorId(Guid id);
        void Atualizar(EventoViewModel eventoViewModel);
        void Excluir(Guid id);
    }
}
