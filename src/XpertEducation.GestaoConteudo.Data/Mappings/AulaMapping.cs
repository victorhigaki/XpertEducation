using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data.Mappings;

public class AulaMapping : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a=> a.Curso)
            .WithMany(c => c.Aulas)
            .HasForeignKey(a => a.CursoId);

        builder.ToTable("Aulas");
    }
}
