using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain;

namespace XpertEducation.GestaoAlunos.Data;

public class AlunosContext : DbContext, IUnitOfWork
{
    public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                           .SelectMany(e => e.GetProperties()
                                           .Where(p => p.ClrType == typeof(string) && p.GetColumnType() is null)))
        {
            property.SetColumnType("varchar(100)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlunosContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
