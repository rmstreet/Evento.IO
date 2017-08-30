
namespace Eventos.IO.Domain.Eventos
{
    using Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id)
        {
            Id = id;
        }

        public string Nome { get; private set; }

        // EF Propriedade de navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        // Construtor para o EF
        protected Categoria() { }

        public override bool EhValido()
        {
            return true;
        }
    }
}