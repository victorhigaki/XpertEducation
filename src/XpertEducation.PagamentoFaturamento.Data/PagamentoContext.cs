﻿using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Data;
using XpertEducation.Core.Messages;
using XpertEducation.PagamentoFaturamento.Business.Models;
using XpertEducation.PagamentoFaturamento.Data.Extensions;

namespace XpertEducation.PagamentoFaturamento.Data;

public class PagamentoContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public PagamentoContext(DbContextOptions<PagamentoContext> options,
                            IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagamentoContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }
}
