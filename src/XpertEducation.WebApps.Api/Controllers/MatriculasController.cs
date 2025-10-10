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
    private readonly IAlunoAppService _alunoAppService;
    private readonly ICursoAppService _cursoAppService;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMatriculaQueries _matriculaQueries;

    public MatriculasController(IAlunoAppService alunoAppService,
        INotificationHandler<DomainNotification> notifications,
        ICursoAppService cursoAppService,
        IMediatorHandler mediatorHandler,
        IAppIdentityUser appIdentityUser,
        IMatriculaQueries matriculaQueries) : base(notifications, mediatorHandler, appIdentityUser)
    {
        _alunoAppService = alunoAppService;
        _cursoAppService = cursoAppService;
        _mediatorHandler = mediatorHandler;
        _matriculaQueries = matriculaQueries;
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
        if (matricula.Status != MatriculaStatus.PendentePagamento)
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
}
