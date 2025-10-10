using MediatR;
using XpertEducation.Core.Messages.IntegrationEvents;
using XpertEducation.PagamentoFaturamento.Business.Models;
using XpertEducation.PagamentoFaturamento.Business.Services;

namespace XpertEducation.PagamentoFaturamento.Business.Events;

public class PagamentoEventHandler : INotificationHandler<MatriculaIniciarPagamentoEvent>
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentoEventHandler(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    public async Task Handle(MatriculaIniciarPagamentoEvent message, CancellationToken cancellationToken)
    {
        var pagamentoPedido = new PagamentoPedido
        {
            MatriculaId = message.MatriculaId,
            ClienteId = message.AlunoId,
            Valor = message.Valor,
            DadosCartao = new DadosCartao
            {
                Nome = message.NomeCartao,
                Numero = message.NumeroCartao,
                Expiracao = message.ExpiracaoCartao,
                Cvv = message.CvvCartao
            }
        };

        await _pagamentoService.RealizarPagamento(pagamentoPedido);
    }
}
