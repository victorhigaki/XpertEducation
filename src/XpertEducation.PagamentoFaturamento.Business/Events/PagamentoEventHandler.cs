using MediatR;
using XpertEducation.Core.Messages.NewFolder;
using XpertEducation.PagamentoFaturamento.Business.Models;
using XpertEducation.PagamentoFaturamento.Business.Services;

namespace XpertEducation.PagamentoFaturamento.Business.Events;

public class PagamentoEventHandler : INotificationHandler<ConfirmadoEvent>
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentoEventHandler(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    public async Task Handle(ConfirmadoEvent message, CancellationToken cancellationToken)
    {
        var pedido = new PagamentoPedido
        {
            PedidoId = message.PedidoId,
            ClienteId = message.ClienteId,
            Total = message.Total,
            DadosCartao = new DadosCartao
            {
                Nome = message.NomeCartao,
                Numero = message.NumeroCartao,
                Expiracao = message.ExpiracaoCartao,
                Cvv = message.CvvCartao
            }
        };

        await _pagamentoService.RealizarPagamento(pedido);
    }
}
