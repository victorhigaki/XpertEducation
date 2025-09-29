using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data.Mappings;

internal class CursoMapping : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.ConteudoProgramatico, cm =>
        {
            cm.Property(c => c.Objetivo)
                .HasColumnName("Objetivo");

            cm.Property(c => c.Conteudo)
                .HasColumnName("Conteudo");

            cm.Property(c => c.Objetivo)
                .HasColumnName("Objetivo");

            cm.Property(c => c.Metodologia)
                .HasColumnName("Metodologia");
        });

        builder.ToTable("Cursos");
    }
}
