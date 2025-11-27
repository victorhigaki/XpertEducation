using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.GestaoAlunos.Application.AppServices;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Application.Queries;
using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoAlunos.Domain.Enums;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Aluno")]
public class MatriculasController : BaseController
{
    private readonly IAlunoQuery _alunoQuery;
    private readonly ICursoAppService _cursoAppService;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMatriculaQueries _matriculaQueries;

    public MatriculasController(INotificationHandler<DomainNotification> notifications,
        ICursoAppService cursoAppService,
        IMediatorHandler mediatorHandler,
        IAppIdentityUser appIdentityUser,
        IMatriculaQueries matriculaQueries,
        IAlunoQuery alunoQuery) : base(notifications, mediatorHandler, appIdentityUser)
    {
        _cursoAppService = cursoAppService;
        _mediatorHandler = mediatorHandler;
        _matriculaQueries = matriculaQueries;
        _alunoQuery = alunoQuery;
    }

    [HttpPost]
    [Route("matricula-aluno")]
    public async Task<IActionResult> MatriculaAlunoAsync(MatriculaAlunoViewModel matriculaAlunoViewModel)
    {
        var curso = await _cursoAppService.ObterPorId(matriculaAlunoViewModel.CursoId);
        if (curso == null)
        {
            return CustomResponse("Curso não encontrado.");
        }

        var command = new MatriculaAlunoCommand(UserId, curso.Id);
        var result = await _mediatorHandler.EnviarComando(command);

        if (!OperacaoValida())
        {
            return CustomResponse();
        }

        return CustomResponse(await _matriculaQueries.ObterMatriculaAluno(UserId));
    }

    [HttpPost("realizar-pagamento-matricula")]
    public async Task<ActionResult> RealizarPagamentoMatricula(PagamentoMatriculaViewModel pagamentoMatriculaViewModel)
    {
        var matricula = await _matriculaQueries.ObterMatriculaAluno(UserId);
        if (matricula.Status != MatriculaStatus.PendentePagamento && matricula.Status != MatriculaStatus.Recusado)
        {
            return BadRequest("Esta ação não pode ser executada");
        }

        var command = new MatriculaIniciarPagamentoCommand(matricula.Id, UserId, 
            pagamentoMatriculaViewModel.DadosCartao.Nome, pagamentoMatriculaViewModel.DadosCartao.Numero , pagamentoMatriculaViewModel.DadosCartao.Expiracao , pagamentoMatriculaViewModel.DadosCartao.Cvv);
        await _mediatorHandler.EnviarComando(command);

        if (!OperacaoValida())
        {
            return CustomResponse();
        }

        return CustomResponse(await _matriculaQueries.ObterMatriculaAluno(UserId));
    }

    [HttpGet("obter-aulas")]
    public async Task<IActionResult> RealizarAula()
    {
        var aluno = await _alunoQuery.ObterPorId(UserId);

        if (aluno == null)
        {
            return BadRequest("Aluno não encontrado");
        }

        return CustomResponse();
    }

    [HttpPost("realizar-aula")]
    public async Task<IActionResult> RealizarAula(RealizarAulaViewModel realizarAulaViewModel)
    {
        var command = new MatriculaRealizarAulaCommand(UserId, realizarAulaViewModel.AulaId);
        await _mediatorHandler.EnviarComando(command);

        return CustomResponse();
    }

    [HttpPost("finalizar-curso")]
    public async Task<ActionResult> FinalizarCurso()
    {
        var matricula = await _matriculaQueries.ObterMatriculaAluno(UserId);
        var curso = await _cursoAppService.ObterPorId(matricula.CursoId);
        var aluno = await _alunoQuery.ObterPorId(UserId);

        var idsAulasCurso = curso.Aulas.Select(a => a.Id).ToList();
        var aulasCursadasAluno = aluno.HistoricoAprendizado.Select(h => h.AulaId).ToList();

        if (idsAulasCurso.All(aulasCursadasAluno.Contains) && aulasCursadasAluno.All(idsAulasCurso.Contains))
        {
            var command = new MatriculaFinalizarCursoCommand(matricula.Id, UserId, matricula.CursoId);
            await _mediatorHandler.EnviarComando(command);
        }

        return CustomResponse();
    }
}
