using Microsoft.EntityFrameworkCore;
using Nota_Fiscal.Domain.Entities;

namespace Stock.Infraestructure.EntitiesConfiguration;

public class NotaFiscalItensConfiguration : IEntityTypeConfiguration< NotaFiscalItem >
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder< NotaFiscalItem > builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.ProdutoId).IsRequired();
        builder.Property(n => n.CodeProduto).HasMaxLength(50);
        builder.Property(n => n.Quantity).IsRequired();
        builder.Property(n => n.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

    }
}
