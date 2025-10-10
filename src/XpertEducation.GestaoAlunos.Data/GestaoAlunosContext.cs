using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.Core.Messages;
using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Data;

public class GestaoAlunosContext : DbContext, IUnitOfWork
{
    public GestaoAlunosContext(DbContextOptions<GestaoAlunosContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                           .SelectMany(e => e.GetProperties()
                                           .Where(p => p.ClrType == typeof(string) && p.GetColumnType() is null)))
        {
            property.SetColumnType("varchar(100)");
        }

        modelBuilder.Ignore<Event>();

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoAlunosContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
