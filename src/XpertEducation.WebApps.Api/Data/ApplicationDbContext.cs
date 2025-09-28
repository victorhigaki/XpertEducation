using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.WebApps.Api.Entities;

namespace XpertEducation.WebApps.Api.Data;

public class ApplicationDbContext : IdentityDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                   .SelectMany(e => e.GetProperties()
                                                   .Where(p => p.ClrType == typeof(string) && p.GetColumnType() is null)))
        {
            property.SetColumnType("varchar(100)");
        }

        base.OnModelCreating(modelBuilder);
    }
}
