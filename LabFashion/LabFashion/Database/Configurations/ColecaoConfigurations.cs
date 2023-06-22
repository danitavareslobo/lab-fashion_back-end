using LabFashion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoFashion.Database.Configurations
{
    public class ColecaoConfigurations : IEntityTypeConfiguration<Colecao>
    {
        public void Configure(EntityTypeBuilder<Colecao> builder)
        {
            _ = builder.HasKey(u => u.Id);

            _ = builder.Property(u => u.NomeColecao)
                .HasMaxLength(Colecao.NomeColecaoMaxLength)
                .IsRequired();

            _ = builder.Property(u => u.IdResponsavel)
                .IsRequired();

            _ = builder.Property(u => u.Marca)
                .HasMaxLength(Colecao.MarcaMaxLength)
                .IsRequired();

            _ = builder.Property(u => u.Orcamento)
                .HasMaxLength(Colecao.OrcamentoMaxLength)
                .IsRequired();

            _ = builder.Property(u => u.AnoLancamento)
                .IsRequired();

            _ = builder.Property(u => u.Estacao)
                .IsRequired();

            _ = builder.Property(u => u.EstadoSistema)
                .IsRequired();

            _ = builder.HasOne(u => u.Usuario)
                .WithOne(c => c.Colecao)
                .HasForeignKey<Colecao>(c => c.IdResponsavel);

            _ = builder.HasMany(u => u.Modelos)
                .WithOne(c => c.Colecao)
                .HasForeignKey(c => c.IdColecaoRelacionada);
        }
    }
}