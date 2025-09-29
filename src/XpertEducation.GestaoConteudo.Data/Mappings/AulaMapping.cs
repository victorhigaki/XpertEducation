using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data.Mappings;

public class AulaMapping : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a=> a.Cursos)
            .WithOne(c => c.Aula)
            .HasForeignKey(c => c.AulaId);

        builder.ToTable("Aulas");
    }
}
