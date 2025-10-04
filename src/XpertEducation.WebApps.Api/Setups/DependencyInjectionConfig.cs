using MediatR;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages.Notifications;
using XpertEducation.GestaoAlunos.Application.AppServices;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Data;
using XpertEducation.GestaoAlunos.Data.Repositories;
using XpertEducation.GestaoAlunos.Domain.Repositories;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Data;
using XpertEducation.GestaoConteudo.Data.Repositories;
using XpertEducation.GestaoConteudo.Domain;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Setups;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

        builder.Services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        builder.Services.AddScoped<IAppIdentityUser, AppIdentityUser>();

        builder.Services.AddScoped<IAlunoAppService, AlunoAppService>();
        builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
        builder.Services.AddScoped<AlunosContext>();

        builder.Services.AddScoped<ICursoAppService, CursoAppService>();
        builder.Services.AddScoped<ICursoRepository, CursoRepository>();
        builder.Services.AddScoped<IAulaAppService, AulaAppService>();
        builder.Services.AddScoped<GestaoConteudoContext>();

        builder.Services.AddScoped<IRequestHandler<AdicionarMatriculaCommand, bool>, MatriculaCommandHandler>();

        return builder;
    }
}
