using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Data.Mappings;

public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(b => b.DadosCartao, dc =>
        {
            dc.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(250)");

            dc.Property(c => c.Numero)
                .IsRequired()
                .HasColumnName("Numero")
                .HasColumnType("varchar(16)");

            dc.Property(c => c.Expiracao)
                .IsRequired()
                .HasColumnName("Expiracao")
                .HasColumnType("varchar(10)");

            dc.Property(c => c.Cvv)
                .IsRequired()
                .HasColumnName("Cvv")
                .HasColumnType("VARCHAR(4)");
        });

        // 1 : 1 => Pagamento : Transacao
        builder.HasOne(c => c.Transacao)
            .WithOne(c => c.Pagamento);

        builder.ToTable("Pagamentos");
    }
}
