using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Notifications;
using XpertEducation.GestaoAlunos.Application.AppServices;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Aluno")]
public class MatriculasController : BaseController
{
    private readonly IAlunoAppService _alunoAppService;
    private readonly ICursoAppService _cursoAppService;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAppIdentityUser _appIdentityUser;

    private Guid AlunoId { get; set; }

    public MatriculasController(IAlunoAppService alunoAppService,
        INotifications notifications,
        ICursoAppService cursoAppService,
        IMediatorHandler mediatorHandler,
        IAppIdentityUser appIdentityUser) : base(notifications)
    {
        _alunoAppService = alunoAppService;
        _cursoAppService = cursoAppService;
        _mediatorHandler = mediatorHandler;
        _appIdentityUser = appIdentityUser;

        AlunoId = appIdentityUser.GetUserId();
    }

    [HttpPost("realizar-matricula/{cursoId:guid}")]
    public async Task<IActionResult> RealizarMatriculaAsync(Guid cursoId)
    {
        var curso = await _cursoAppService.ObterCursoPorIdAsync(cursoId);
        if (curso == null)
        {
            return BadRequest("Curso não encontrado.");
        }

        var command = new AdicionarAlunoCursoCommand(AlunoId, curso.Id, curso.Nome);
        await _mediatorHandler.EnviarComando(command);

        return CustomResponse();
    }
}
