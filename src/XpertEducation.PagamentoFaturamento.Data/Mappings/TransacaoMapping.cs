using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Data.Mappings;

public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(c => c.Id);

        builder.ToTable("Transacoes");
    }
}
