using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Data.Mappings;

public class AlunoMapping : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(a => a.Id);

        builder.OwnsMany(a => a.HistoricoAprendizado);

        builder.ToTable("Alunos");
    }
}
