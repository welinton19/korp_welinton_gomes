using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nota_Fiscal.Domain.Entities;

namespace Nota_Fiscal.Infrastructure.EntitiesConfiguration;

public class NotaFiscalItensConfiguration : IEntityTypeConfiguration<NotaFiscalItem>
{
    public void Configure(EntityTypeBuilder<NotaFiscalItem> builder)
    {
        builder.HasAlternateKey(i => i.Id);
        builder.Property(i => i.ProdutoId).IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.UnitPrice).IsRequired();
    }
}
