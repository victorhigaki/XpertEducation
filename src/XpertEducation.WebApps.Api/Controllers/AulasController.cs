using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Notifications;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Admin")]
public class AulasController : BaseController
{
    private readonly IAulaAppService _aulaAppService;

    public AulasController(IAulaAppService aulaAppService, 
                           INotifications notifications) : base(notifications)
    {
        _aulaAppService = aulaAppService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAulaAsync(AulaViewModel aulaViewModel)
    {
        await _aulaAppService.AdicionarAula(aulaViewModel);
        return CustomResponse(aulaViewModel);
    }
}
