using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data.Mappings;

internal class CursoMapping : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(c => c.Id);

        builder.ToTable("Cursos");
    }
}
