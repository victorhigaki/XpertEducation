using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

public class AulasController : BaseController
{
    private readonly IAulaAppService _aulaAppService;
    private readonly IMediatorHandler _mediatorHandler;

    public Guid AlunoId { get; private set; }

    public AulasController(IAulaAppService aulaAppService,
                           IAppIdentityUser appIdentityUser,
                           INotificationHandler<DomainNotification> notifications,
                           IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler, appIdentityUser)
    {
        _aulaAppService = aulaAppService;
        _mediatorHandler = mediatorHandler;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("cadastro-aula")]
    public async Task<IActionResult> AdicionarAula(AulaViewModel aulaViewModel)
    {
        var curso = _aulaAppService.ObterCursoPorId(aulaViewModel.CursoId);
        if (curso == null) return BadRequest();

        await _aulaAppService.AdicionarAula(aulaViewModel);
        return CustomResponse(aulaViewModel);
    }

    [Authorize(Roles = "Aluno")]
    [HttpPost("realizar-aula")]
    public async Task<IActionResult> RealizarAula(RealizarAulaViewModel realizarAulaViewModel)
    {
        var command = new RealizarAulaCommand(UserId, realizarAulaViewModel.AulaId);
        await _mediatorHandler.EnviarComando(command);

        return CustomResponse();
    }
}
