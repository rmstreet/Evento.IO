
namespace Eventos.IO.Infra.Data.Mappings
{    
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Eventos.IO.Domain.Eventos;
    using Extensions;
    

    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public override void Map(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .Property(c => c.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Ignore(c => c.ValidationResult);

            builder
                .Ignore(c => c.CascadeMode);

            builder
                .ToTable("Categorias");
        }
    }
}
