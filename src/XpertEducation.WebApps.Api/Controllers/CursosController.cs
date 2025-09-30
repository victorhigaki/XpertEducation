using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Notifications;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Admin")]
public class CursosController : BaseController
{
    private readonly ICursoAppService _cursoAppService;

    public CursosController(ICursoAppService cursoAppService, INotifications notifications) : base(notifications)
    {
        _cursoAppService = cursoAppService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarCursoAsync(CursoViewModel cursoViewModel)
    {
        await _cursoAppService.CriarCurso(cursoViewModel);
        return CustomResponse(cursoViewModel);
    }
}
