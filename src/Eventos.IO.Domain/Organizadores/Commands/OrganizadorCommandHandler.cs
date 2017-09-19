
namespace Eventos.IO.Domain.Organizadores.Commands
{
    using CommandHandlers;
    using Core.Bus;
    using Core.Notifications;
    using Core.Events;
    using Interfaces;
    using Repository;
    using System.Linq;
    using global::Eventos.IO.Domain.Organizadores.Events;

    public class OrganizadorCommandHandler : CommandHandler,
        IHandler<RegistrarOrganizadorCommand>
    {
        private readonly IBus _bus;
        private readonly IOrganizadorRepository _organizadorRepository;
               

        public OrganizadorCommandHandler(IUnitOfWork uow, 
                                         IBus bus, 
                                         IDomainNotificationHandler<DomainNotification> notifications,
                                         IOrganizadorRepository organizadorRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _organizadorRepository = organizadorRepository;
        }

        public void Handle(RegistrarOrganizadorCommand message)
        {
            var organizador = new Organizador(message.Id, message.Nome, message.CPF, message.Email);

            if (!organizador.EhValido())
            {
                NotificarValidacoesErro(organizador.ValidationResult);
                return;
            }

            var organizadorExistente = _organizadorRepository.Buscar(o => o.CPF == organizador.CPF || o.Email == organizador.Email);

            if (organizadorExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _organizadorRepository.Adicionar(organizador);

            if (Commit())
            {
                _bus.RaiseEvent(new OrganizadorRegistradoEvent(organizador.Id, organizador.Nome, organizador.CPF, organizador.Email));
            }

        }
    }
}
