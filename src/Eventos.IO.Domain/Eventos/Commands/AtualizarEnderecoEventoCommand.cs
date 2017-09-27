
namespace Eventos.IO.Domain.Eventos.Commands
{
    using Domain.Core.Commands;
    using System;

    public class AtualizarEnderecoEventoCommand : Command
    {
        public AtualizarEnderecoEventoCommand(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid? eventoId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;           
        }

        public Guid Id { get; protected set; }
        public string Logradouro { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string CEP { get; protected set; }
        public string Cidade { get; protected set; }
        public string Estado { get; protected set; }
        public Guid? EventoId { get; protected set; }
    }
}
