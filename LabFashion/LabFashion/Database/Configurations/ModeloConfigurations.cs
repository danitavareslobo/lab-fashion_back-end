using LabFashion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoFashion.Database.Configurations
{
    public class ModeloConfigurations : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            _ = builder.HasKey(u => u.Id);

            _ = builder.Property(u => u.NomeModelo)
                .HasMaxLength(Modelo.NomeModeloMaxLength)
                .IsRequired();

            _ = builder.Property(u => u.IdColecaoRelacionada)
                .IsRequired();

            _ = builder.Property(u => u.Tipo)
                .IsRequired();

            _ = builder.Property(u => u.Layout)
                .IsRequired();

        }
    }
}