
namespace Eventos.IO.Domain.Eventos.Command
{
    using System;
    using Domain.Core.Notifications;
    using Domain.Core.Events;
    using Domain.CommandHandlers;
    using Domain.Interfaces;
    using Commands;
    using Repository;
    using Domain.Core.Bus;
    using Events;    

    public class EventoCommandHandler :
        CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;

        public EventoCommandHandler(
            IEventoRepository eventoRepository,
            IUnitOfWork uow, 
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                message.DescricaoLonga, message.DataInicio, message.DataFim, message.Gratuito, message.Valor,
                message.Online, message.NomeEmpresa, message.OrganizadorId, message.Endereco, message.Categoria.Id);

            if (!EventoValido(evento)) return;

            // TODO: 
            // Validações de negocio.
            // Organizador pode registrar evento?

            // Presistencia
            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var eventoAtual = _eventoRepository.ObterPorId(message.Id);

            if (!EventoExistente(message.Id, message.MessageType)) return;

            // TODO: Validar e o evento pertene a pessoa que está editando.

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta, message.DescricaoLonga, 
                                                                 message.DataInicio, message.DataFim, message.Gratuito, message.Valor,
                                                                 message.Online, message.NomeEmpresa, message.OrganizadorId, message.Endereco,
                                                                 message.Categoria.Id);

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoAtualizadoEvent(evento.Id, evento.Nome, evento.DescricaoCurta, evento.DescricaoLonga, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;

            _eventoRepository.Remover(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
            }
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;            
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);

            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrato."));
            return false;
        }
    }
}
