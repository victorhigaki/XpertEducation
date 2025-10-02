using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Notifications;
using XpertEducation.GestaoAlunos.Application.AppServices;
using XpertEducation.GestaoAlunos.Domain.Enums;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.PagamentoFaturamento.Application.ViewModels;

namespace XpertEducation.WebApps.Api.Controllers;

[Authorize(Roles = "Aluno")]
public class PagamentosController : BaseController
{
    private readonly IAulaAppService _aulaAppService;
    private readonly IAlunoAppService _alunoAppService;

    public PagamentosController(IAulaAppService aulaAppService,
                                IAlunoAppService alunoAppService,
                                INotifications notifications) : base(notifications)
    {
        _aulaAppService = aulaAppService;
        _alunoAppService = alunoAppService;
    }

    [HttpPost("realizar-pagamento")]
    public async Task<ActionResult> RealizarPagamento(PagamentoViewModel pagamentoViewModel)
    {
        var matricula = await _alunoAppService.ObterMatriculaPorIdAsync(pagamentoViewModel.MatriculaId);
        if (matricula.Status != MatriculaStatus.PendentePagamento)
        {
            return CustomResponse();
        }

        return CustomResponse();
    }
}
