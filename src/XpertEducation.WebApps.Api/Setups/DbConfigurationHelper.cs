using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XpertEducation.GestaoAlunos.Data;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoConteudo.Data;
using XpertEducation.PagamentoFaturamento.Data;
using XpertEducation.WebApps.Api.Data;
using XpertEducation.WebApps.Api.Entities;

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
        var alunosContext = scope.ServiceProvider.GetRequiredService<GestaoAlunosContext>();
        var gestaoConteudoContext = scope.ServiceProvider.GetRequiredService<GestaoConteudoContext>();
        var pagamentoContext = scope.ServiceProvider.GetRequiredService<PagamentoContext>();

        if (env.IsDevelopment() || env.IsEnvironment("Testing"))
        {
            await contextId.Database.MigrateAsync();
            await alunosContext.Database.MigrateAsync();
            await gestaoConteudoContext.Database.MigrateAsync();
            await pagamentoContext.Database.MigrateAsync();
        }

        await EnsureSeedProducts(contextId, alunosContext);
    }

    public static async Task EnsureSeedProducts(ApplicationDbContext contextId, GestaoAlunosContext context)
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
        var userId = Guid.NewGuid();
        await contextId.Users.AddAsync(new IdentityUser
        {
            Id = userId.ToString(),
            UserName = "test@test.com",
            NormalizedUserName = "TEST@TEST.COM",
            Email = "test@test.com",
            NormalizedEmail = "TEST@TEST.COM",
            AccessFailedCount = 0,
            LockoutEnabled = false,
            PasswordHash = "AQAAAAIAAYagAAAAEJBy+Pk+9pYc6ztX5gYC9F4art+lPISTgIOR1Q0XUHiI3YtYPdg9U+xkF5ZA53Qs8g==", // Teste@12345
            TwoFactorEnabled = false,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        });

        var adminRoleId = Guid.NewGuid().ToString();
        var userRoleId = Guid.NewGuid().ToString();
        await contextId.Roles.AddRangeAsync(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
             new IdentityRole
             {
                 Id = userRoleId,
                 Name = "Aluno",
                 NormalizedName = "ALUNO",
                 ConcurrencyStamp = Guid.NewGuid().ToString()
             });
        await contextId.UserRoles.AddAsync(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminId.ToString()
        });
        await contextId.UserRoles.AddAsync(new IdentityUserRole<string>
        {
            RoleId = userRoleId,
            UserId = userId.ToString()
        });

        await contextId.Admins.AddAsync(new Admin
        {
            Id = adminId
        });

        await context.Alunos.AddAsync(new Aluno(userId));

        await contextId.SaveChangesAsync();
        await context.SaveChangesAsync();
    }
}
