using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Data;
using XpertEducation.Core.Messages;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data;

public class GestaoConteudoContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public GestaoConteudoContext(DbContextOptions<GestaoConteudoContext> options, 
                                 IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
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

        modelBuilder.Ignore<Event>();

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoConteudoContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        var sucesso = await base.SaveChangesAsync() > 0;
        if (sucesso) await _mediatorHandler.PublicarEventos(this);

        return sucesso;
    }
}
