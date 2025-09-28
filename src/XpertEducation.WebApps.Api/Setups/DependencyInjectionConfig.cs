using XpertEducation.GestaoAlunos.Application;
using XpertEducation.GestaoAlunos.Data;

namespace XpertEducation.WebApps.Api.Setups;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAlunoAppService, AlunoAppService>();
        builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
        builder.Services.AddScoped<AlunosContext>();
        return builder;
    }
}
