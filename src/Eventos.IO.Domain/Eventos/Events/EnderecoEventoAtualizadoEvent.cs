
namespace Eventos.IO.Domain.Eventos.Events
{
    using Core.Events;
    using System;

    public class EnderecoEventoAtualizadoEvent : Event
    {

        public Guid Id { get; protected set; }
        public string Logradouro { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string CEP { get; protected set; }
        public string Cidade { get; protected set; }
        public string Estado { get; protected set; }

        public EnderecoEventoAtualizadoEvent(Guid enderecoId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid eventoId)
        {
            Id = enderecoId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            AggregateId = eventoId;
        }

    }
}
