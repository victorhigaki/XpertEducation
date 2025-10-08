using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoAlunos.Application.AppServices;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoAlunos.Domain.Enums;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Aluno")]
public class MatriculasController : BaseController
{
    private readonly IAlunoAppService _alunoAppService;
    private readonly ICursoAppService _cursoAppService;
    private readonly IMediatorHandler _mediatorHandler;

    private Guid AlunoId { get; set; }

    public MatriculasController(IAlunoAppService alunoAppService,
        INotificationHandler<DomainNotification> notifications,
        ICursoAppService cursoAppService,
        IMediatorHandler mediatorHandler,
        IAppIdentityUser appIdentityUser) : base(notifications, mediatorHandler)
    {
        _alunoAppService = alunoAppService;
        _cursoAppService = cursoAppService;
        _mediatorHandler = mediatorHandler;

        AlunoId = appIdentityUser.GetUserId();
    }

    [HttpGet]
    public async Task<IActionResult> Teste()
    {
        return Ok();
    }

    [HttpPost]
    [Route("matricula-aluno")]
    public async Task<IActionResult> MatriculaAlunoAsync(MatriculaAlunoViewModel matriculaAlunoViewModel)
    {
        var curso = await _cursoAppService.ObterPorIdAsync(matriculaAlunoViewModel.CursoId);
        if (curso == null)
        {
            return CustomResponse("Curso não encontrado.");
        }

        var command = new MatriculaAlunoCommand(AlunoId, curso.Id);
        await _mediatorHandler.EnviarComando(command);

        return CustomResponse();
    }

    [HttpPost("realizar-pagamento-matricula")]
    public async Task<ActionResult> RealizarPagamentoMatricula(PagamentoMatriculaViewModel pagamentoMatriculaViewModel)
    {
        var matricula = await _alunoAppService.ObterMatriculaPorIdAsync(pagamentoMatriculaViewModel.MatriculaId);
        if (matricula.Status != MatriculaStatus.PendentePagamento)
        {
            return CustomResponse("Esta ação não pode ser executada");
        }

        await _mediatorHandler.EnviarComando(new RealizarPagamentoMatriculaCommand(pagamentoMatriculaViewModel.MatriculaId, AlunoId));
        return CustomResponse();
    }
}
