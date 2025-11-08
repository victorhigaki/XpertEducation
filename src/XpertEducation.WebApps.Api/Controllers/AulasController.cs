using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

public class AulasController : BaseController
{
    private readonly ICursoAppService _cursoAppService;

    public Guid AlunoId { get; private set; }

    public AulasController(ICursoAppService cursoAppService,
                           IAppIdentityUser appIdentityUser,
                           INotificationHandler<DomainNotification> notifications,
                           IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler, appIdentityUser)
    {
        _cursoAppService = cursoAppService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("cadastro-aula")]
    public async Task<IActionResult> AdicionarAula(AulaViewModel aulaViewModel)
    {
        var curso = _cursoAppService.ObterPorId(aulaViewModel.CursoId);
        if (curso == null) return BadRequest();
        await _cursoAppService.AdicionarAula(aulaViewModel);
        return CustomResponse(aulaViewModel);
    }
}
