
namespace Eventos.IO.Domain.Eventos.Commands
{
    using System;

    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(string nome,
                      DateTime dataInicio,
                      DateTime dataFim,
                      bool gratuito,
                      decimal valor,
                      bool online,
                      string nomeEmpresa)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
        }
    }
}
