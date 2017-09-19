
namespace Eventos.IO.Domain.Organizadores.Events
{
    using Core.Events;
    using System;

    public class OrganizadorRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public OrganizadorRegistradoEvent(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }
    }
}
