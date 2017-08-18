
namespace Eventos.IO.Domain.Organizadores
{
    using Domain.Core.Models;
    using System;

    public class Organizador : Entity<Organizador>
    {
        public Organizador(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}