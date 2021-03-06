﻿
namespace Eventos.IO.Application.Services
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using ViewModels;
    using Domain.Core.Bus;
    using Domain.Eventos.Commands;
    using global::AutoMapper;
    using Eventos.IO.Domain.Eventos.Repository;
    using Eventos.IO.Domain.Interfaces;

    public class EventoAppService : IEventoAppService
    {

        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventoRepository _eventoRepository;
        private readonly IUser _user;


        public EventoAppService(IBus bus, 
                                IMapper mapper, 
                                IEventoRepository eventoRepository, 
                                IUser user)
        {
            _bus = bus;
            _mapper = mapper;
            _eventoRepository = eventoRepository;
            _user = user;
        }

        public void Registrar(EventoViewModel eventoViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(registroCommand);
        }        

        public List<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
        {
            // TODO: A expressão deveria ser um scope(definido na camada de domain)

            return _mapper.Map<List<EventoViewModel>>(_eventoRepository.ObterTodos(default(int),
                                                                                   default(int),
                                                                                   f => f.OrganizadorId == organizadorId));
        }

        public EventoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.ObterPorId(id));
        }

        public List<EventoViewModel> ObterTodos()
        {
            return _mapper.Map<List<EventoViewModel>>(_eventoRepository.ObterTodos());
        }

        public void Atualizar(EventoViewModel eventoViewModel)
        {
            // TODO: Validar se o organizador é dono do evento.

            var atualizarEventoCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(atualizarEventoCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirEventoCommand(id));
        }

        public void AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var enderecoCommand = _mapper.Map<IncluirEnderecoEventoCommand>(enderecoViewModel);
            _bus.SendCommand(enderecoCommand);
        }

        public void AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var enderecoCommand = _mapper.Map<AtualizarEnderecoEventoCommand>(enderecoViewModel);
            _bus.SendCommand(enderecoCommand);
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_eventoRepository.ObterEnderecoPorId(id));
        }

        public void Dispose()
        {
            _eventoRepository.Dispose();
        }

        
    }
}
