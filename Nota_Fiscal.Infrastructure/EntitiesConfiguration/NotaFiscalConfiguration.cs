using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nota_Fiscal.Domain.Entities;

namespace Nota_Fiscal.Infrastructure.EntitiesConfiguration;

public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
{
    public void Configure(EntityTypeBuilder<NotaFiscal> builder)
    {
        builder.HasAlternateKey(n => n.Id);
        builder.Property(n => n.Number)
            .HasMaxLength(20)
            .IsRequired(false);
        builder.Property(n => n.ClientName)
            .HasMaxLength(100)
            .IsRequired();

    }
}
