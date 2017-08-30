
namespace Eventos.IO.Infra.Data.Mappings
{    
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Eventos.IO.Domain.Organizadores;
    using Extensions;

    public class OrganizadorMapping : EntityTypeConfiguration<Organizador>
    {
        public override void Map(EntityTypeBuilder<Organizador> builder)
        {
            builder
                .Property(o => o.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(o => o.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Ignore(o => o.ValidationResult);

            builder
                .Ignore(o => o.CascadeMode);

            builder
                .ToTable("Organizadores");
        }
    }
}
