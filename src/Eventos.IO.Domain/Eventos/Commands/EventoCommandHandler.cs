
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
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim, message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);
            if (!EventoValido(evento)) return;

            // TODO: 
            // Validações de negocio.
            // Organizador pode registrar evento?

            // Presistencia
            _eventoRepository.Add(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome,  message.DescricaoCurta,
                                                                 message.DescricaoLonga, message.DataInicio,
                                                                 message.DataFim,
                                                                 message.Gratuito,
                                                                 message.Valor,
                                                                 message.Online,
                                                                 message.NomeEmpresa,
                                                                 null);

            if (!EventoValido(evento)) return;

            _eventoRepository.Update(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoAtualizadoEvent(evento.Id, evento.Nome, evento.DescricaoCurta, evento.DescricaoLonga, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;

            _eventoRepository.Remove(message.Id);

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
            var evento = _eventoRepository.GetById(id);

            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrato."));
            return false;
        }
    }
}
