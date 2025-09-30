using XpertEducation.Core.Notifications;
using XpertEducation.GestaoAlunos.Application;
using XpertEducation.GestaoAlunos.Data;
using XpertEducation.GestaoAlunos.Data.Repositories;
using XpertEducation.GestaoAlunos.Domain;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Data;
using XpertEducation.GestaoConteudo.Data.Repositories;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.WebApps.Api.Setups;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<INotifications, Notifications>();

        builder.Services.AddScoped<IAlunoAppService, AlunoAppService>();
        builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
        builder.Services.AddScoped<AlunosContext>();

        builder.Services.AddScoped<ICursoAppService, CursoAppService>();
        builder.Services.AddScoped<ICursoRepository, CursoRepository>();
        builder.Services.AddScoped<IAulaAppService, AulaAppService>();
        builder.Services.AddScoped<GestaoConteudoContext>();

        return builder;
    }
}
