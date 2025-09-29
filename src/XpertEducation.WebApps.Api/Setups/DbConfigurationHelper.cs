using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XpertEducation.GestaoAlunos.Data;
using XpertEducation.GestaoConteudo.Data;
using XpertEducation.WebApps.Api.Data;

namespace XpertEducation.WebApps.Api.Setups;

public static class DbMigrationHelperExtension
{
    public static void UseDbMigrationHelper(this WebApplication app)
    {
        DbMigrationHelpers.EnsureSeedData(app).Wait();
    }
}

public static class DbMigrationHelpers
{

    public static async Task EnsureSeedData(WebApplication serviceScope)
    {
        var services = serviceScope.Services.CreateScope().ServiceProvider;
        await EnsureSeedData(services);
    }

    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var contextId = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var alunosContext = scope.ServiceProvider.GetRequiredService<AlunosContext>();
        var gestaoConteudoContext = scope.ServiceProvider.GetRequiredService<GestaoConteudoContext>();

        if (env.IsDevelopment())
        {
            await contextId.Database.MigrateAsync();
            await alunosContext.Database.MigrateAsync();
            await gestaoConteudoContext.Database.MigrateAsync();
        }

        await EnsureSeedProducts(contextId);
    }

    public static async Task EnsureSeedProducts(ApplicationDbContext contextId)
    {
        if (contextId.Users.Any())
            return;
        var adminId = Guid.NewGuid();
        await contextId.Users.AddAsync(new IdentityUser
        {
            Id = adminId.ToString(),
            UserName = "admin@xpert.com",
            NormalizedUserName = "ADMIN@XPERT.COM",
            Email = "admin@xpert.com",
            NormalizedEmail = "ADMIN@XPERT.COM",
            AccessFailedCount = 0,
            LockoutEnabled = false,
            PasswordHash = "AQAAAAIAAYagAAAAEJBy+Pk+9pYc6ztX5gYC9F4art+lPISTgIOR1Q0XUHiI3YtYPdg9U+xkF5ZA53Qs8g==", // Teste@12345
            TwoFactorEnabled = false,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        });
        await contextId.Admins.AddAsync(new Entities.Admin
        {
            Id = adminId
        });

        await contextId.SaveChangesAsync();
    }
}
