using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data;

public class GestaoConteudoContext : DbContext, IUnitOfWork
{
    public GestaoConteudoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Aula> Aulas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                           .SelectMany(e => e.GetProperties()
                                           .Where(p => p.ClrType == typeof(string) && p.GetColumnType() is null)))
        {
            property.SetColumnType("varchar(100)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoConteudoContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
