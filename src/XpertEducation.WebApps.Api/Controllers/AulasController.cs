using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Admin")]
public class AulasController : BaseController
{
    private readonly IAulaAppService _aulaAppService;

    public AulasController(IAulaAppService aulaAppService,
                           INotificationHandler<DomainNotification> notifications,
                           MediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
    {
        _aulaAppService = aulaAppService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAulaAsync(AulaViewModel aulaViewModel)
    {
        var curso = _aulaAppService.ObterCursoPorId(aulaViewModel.CursoId);
        if (curso == null) return BadRequest();

        await _aulaAppService.AdicionarAula(aulaViewModel);
        return CustomResponse(aulaViewModel);
    }
}
