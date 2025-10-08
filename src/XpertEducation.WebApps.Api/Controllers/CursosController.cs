using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Admin")]
public class CursosController : BaseController
{
    private readonly ICursoAppService _cursoAppService;

    public CursosController(ICursoAppService cursoAppService, 
                            INotificationHandler<DomainNotification> notifications,
                            IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
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
        await _cursoAppService.AdicionarAsync(cursoViewModel);
        return CustomResponse(cursoViewModel);
    }
}
