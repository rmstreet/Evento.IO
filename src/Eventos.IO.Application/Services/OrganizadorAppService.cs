
namespace Eventos.IO.Application.Services
{
    using Eventos.IO.Domain.Core.Bus;
    using Eventos.IO.Domain.Organizadores.Commands;
    using Eventos.IO.Domain.Organizadores.Repository;
    using global::AutoMapper;
    using Interfaces;
    using System;
    using ViewModels;

    public class OrganizadorAppService : IOrganizadorAppService
    {

        private readonly IMapper _mapper;
        private readonly IOrganizadorRepository _organizadorRepository;
        private readonly IBus _bus;

        public OrganizadorAppService(IMapper mapper, IOrganizadorRepository organizadorRepository, IBus bus)
        {
            _mapper = mapper;
            _organizadorRepository = organizadorRepository;
            _bus = bus;
        }

        public void Registrar(OrganizadorViewModel organizadorViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarOrganizadorCommand>(organizadorViewModel);
            _bus.SendCommand(registroCommand);
        }

        public void Dispose()
        {
            _organizadorRepository.Dispose();
        }
    }
}
