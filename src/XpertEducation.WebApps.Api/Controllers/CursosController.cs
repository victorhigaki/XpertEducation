using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Admin")]
public class CursosController : BaseController
{
    private readonly ICursoAppService _cursoAppService;

    public CursosController(ICursoAppService cursoAppService, 
                            INotificationHandler<DomainNotification> notifications,
                            IMediatorHandler mediatorHandler,
                            IAppIdentityUser appIdentityUser) : base(notifications, mediatorHandler, appIdentityUser)
    {
        _cursoAppService = cursoAppService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodosCursoAsync()
    {
        var result = await _cursoAppService.ObterTodosAsync();
        return CustomResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarCursoAsync(CursoViewModel cursoViewModel)
    {
        var result = await _cursoAppService.AdicionarAsync(cursoViewModel);
        return CustomResponse(result);
    }
}
