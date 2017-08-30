﻿
namespace Eventos.IO.Infra.Data.Mappings
{
    using Eventos.IO.Domain.Eventos;
    using Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventoMapping : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder
                .Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)"); // No EFC isso pode informar o tamanho do varchar.

            builder
                .Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.NomeEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Ignore(e => e.ValidationResult);

            builder
                .Ignore(e => e.Tags);

            builder
                .Ignore(e => e.CascadeMode);

            builder
                .ToTable("Eventos");

            builder
                .HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId);

            builder
                .HasOne(e => e.Categoria)
                .WithMany(e => e.Eventos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false);
        }
    }
}
