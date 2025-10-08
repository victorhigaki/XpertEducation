using MediatR;
using NerdStore.Pagamentos.AntiCorruption;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages.NewFolder;
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
using XpertEducation.PagamentoFaturamento.AntiCorruption;
using XpertEducation.PagamentoFaturamento.Business.Events;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Services;
using XpertEducation.PagamentoFaturamento.Data;
using XpertEducation.PagamentoFaturamento.Data.Repositories;
using XpertEducation.WebApps.Api.Extensions;
using ConfigurationManager = NerdStore.Pagamentos.AntiCorruption.ConfigurationManager;
using IConfigurationManager = NerdStore.Pagamentos.AntiCorruption.IConfigurationManager;

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

        builder.Services.AddScoped<IRequestHandler<MatriculaAlunoCommand, bool>, MatriculaCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<RealizarPagamentoMatriculaCommand, bool>, MatriculaCommandHandler>();

        builder.Services.AddScoped<IPagamentoService, PagamentoService>();
        builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        builder.Services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
        builder.Services.AddScoped<IPayPalGateway, PayPalGateway>();
        builder.Services.AddScoped<IConfigurationManager, ConfigurationManager>();
        builder.Services.AddScoped<PagamentoContext>();

        builder.Services.AddScoped<INotificationHandler<ConfirmadoEvent>, PagamentoEventHandler>();

        return builder;
    }
}
