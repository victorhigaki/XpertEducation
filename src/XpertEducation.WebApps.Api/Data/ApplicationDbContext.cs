using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace XpertEducation.WebApps.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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
}
